using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Enums.ReadingModule;
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
			using (SerialPort port = new SerialPort(readingModule.Port_or_AddressIP))
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
				registers = await master.ReadHoldingRegistersAsync(slaveId, startAddress, numRegisters);
			};
		}
		else if (readingModule.CommunicationType == CommunicationType.TCP)
		{
			using (TcpClient client = new TcpClient(readingModule.Port_or_AddressIP, 502))
			{
                var master = ModbusIpMaster.CreateIp(client);

				// read registers		
				registers = await master.ReadHoldingRegistersAsync(slaveId, startAddress, numRegisters);
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
			sensor1 = registers[0],
			sensor2 = registers[1],
			sensor3 = registers[2],
			sensor4 = registers[3],
			sensor5 = registers[4],
			sensor6 = registers[5],
			sensor7 = registers[6],
			sensor8 = registers[7],
			sensor9 = registers[8],
			sensor10 = registers[9],
			sensor11 = registers[10],
			sensor12 = registers[11],
			sensor13 = registers[12],
			sensor14 = registers[13],
			sensor15 = registers[14],
			sensor16 = registers[15],
			sensor17 = registers[16],
			sensor18 = registers[17],
			sensor19 = registers[18],
			sensor20 = registers[19],
			sensor21 = registers[20],
			sensor22 = registers[21],
			sensor23 = registers[22],
			sensor24 = registers[23],
			sensor25 = registers[24],
			sensor26 = registers[25],
			sensor27 = registers[26],
			sensor28 = registers[27],
			sensor29 = registers[28],
			sensor30 = registers[29],
			sensor31 = registers[30],
			sensor32 = registers[31],
			sensor33 = registers[32],
			sensor34 = registers[33],
			sensor35 = registers[34],
			sensor36 = registers[35],
			sensor37 = registers[36],
			sensor38 = registers[37],
			sensor39 = registers[38],
			sensor40 = registers[39],
			sensor41 = registers[40],
			sensor42 = registers[41],
			sensor43 = registers[42],
			sensor44 = registers[43],
			sensor45 = registers[44],
			sensor46 = registers[45],
			sensor47 = registers[46],
			sensor48 = registers[47],
			sensor49 = registers[48],
			sensor50 = registers[49],
			sensor51 = registers[50],
			sensor52 = registers[51],
			sensor53 = registers[52],
			sensor54 = registers[53],
			sensor55 = registers[54],
			sensor56 = registers[55],
			sensor57 = registers[56],
			sensor58 = registers[57],
			sensor59 = registers[58],
			sensor60 = registers[59],
			sensor61 = registers[60],
			sensor62 = registers[61],
			sensor63 = registers[62],
			sensor64 = registers[63],
			sensor65 = registers[64],
			sensor66 = registers[65],
			sensor67 = registers[66],
			sensor68 = registers[67],
			sensor69 = registers[68],
			sensor70 = registers[69],
			sensor71 = registers[70],
			sensor72 = registers[71],
			sensor73 = registers[72],
			sensor74 = registers[73],
			sensor75 = registers[74],
			sensor76 = registers[75],
			sensor77 = registers[76],
			sensor78 = registers[77],
			sensor79 = registers[78],
			sensor80 = registers[79],
			sensor81 = registers[80],
			sensor82 = registers[81],
			sensor83 = registers[82],
			sensor84 = registers[83],
			sensor85 = registers[84],
			sensor86 = registers[85],
			sensor87 = registers[86],
			sensor88 = registers[87],
			sensor89 = registers[88],
			sensor90 = registers[89],
			sensor91 = registers[90],
			sensor92 = registers[91],
			sensor93 = registers[92],
			sensor94 = registers[93],
			sensor95 = registers[94],
			sensor96 = registers[95],
			sensor97 = registers[96],
			sensor98 = registers[97],
			sensor99 = registers[98],
			sensor100 = registers[99],
		};

		return temperature;
	}
}
