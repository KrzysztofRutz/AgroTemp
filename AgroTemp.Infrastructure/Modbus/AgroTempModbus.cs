using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
using AgroTemp.Infrastructure.Modbus.Configuration;
using Modbus.Device;
using System.IO.Ports;
using System.Net.Sockets;

namespace AgroTemp.Infrastructure.Modbus;

internal static class AgroTempModbus 
{
	public static async Task<Temperature> ReadRegistersAsync(ReadingModule readingModule)
	{
		ushort[] registers = new ushort[100];
        byte slaveId = (byte)readingModule.ModuleID;
        const ushort startAddress = 100;
		ushort numRegisters = (readingModule.ModuleType == ModuleType.Elecso) ? (ushort)100 : (ushort)64;

        if (readingModule.CommunicationType == CommunicationType.RTU)
		{
			using (var port = new SerialPort(readingModule.Port_or_AddressIP))
			{
				// configure serial port
				port.BaudRate = (int)readingModule.Baudrate;
				port.DataBits = readingModule.BitsOfSign;
				port.Parity = readingModule.Parity;
				port.StopBits = readingModule.StopBit;
				port.Open();

				// create modbus master
				var master = ModbusSerialMaster.CreateRtu(port);

                // read registers
                registers = await RetryHelper.RetryAsync(async () => await master.ReadHoldingRegistersAsync(slaveId, startAddress, numRegisters), TimeSpan.FromSeconds(1), 3);		
			};
		}
		else if (readingModule.CommunicationType == CommunicationType.TCP)
		{
			using (var client = new TcpClient(readingModule.Port_or_AddressIP, 502))
			{
                var master = ModbusIpMaster.CreateIp(client);

                // read registers		
                registers = await RetryHelper.RetryAsync(async () => await master.ReadHoldingRegistersAsync(slaveId, startAddress, numRegisters), TimeSpan.FromSeconds(1), 3);
            }
        }

		if (readingModule.ModuleType == ModuleType.Elecso)
		{
			for (int i = 0; i < registers.Length; i++)
			{
				int intRegisters = registers[i];
				registers[i] = (ushort)(intRegisters * 6.25);
			}
		}

		var temperature = new Temperature()
		{
			ReadingModuleId = readingModule.Id,
		};

        for (int i = 1; i <= 100; i++)
        {
            typeof(Temperature).GetProperty($"sensor{i}").SetValue(temperature, registers[i - 1]);
        }

        return temperature;
	}
}
