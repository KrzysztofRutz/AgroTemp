using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgroTemp.Infrastructure.Repositories;

internal class DeltaTemperatureRepository : IDeltaTemperatureRepository
{
    private readonly AgroTempDbContext _dbContext;

    public DeltaTemperatureRepository(AgroTempDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<DeltaTemperature> GetActualMeasureByReadingModuleIdAsync(int readingModuleId)
        => await _dbContext.DeltaTemperatures.Where(x => x.ReadingModuleId == readingModuleId).FirstAsync();

    public async Task<IEnumerable<DeltaTemperature>> GetByReadingModuleIdAndBetweenStartDateTimeAndEndTimeAsync(int readingModuleId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default)
        => await _dbContext.DeltaTemperatures.Where(x => x.ReadingModuleId == readingModuleId & x.CreatedAt > startDateTime & x.CreatedAt <= endDateTime & x.CreatedAt.Minute == 0).ToListAsync(cancellationToken);

    public async Task<IEnumerable<DeltaTemperature>> GetByReadingModuleIdAsync(int readingModuleId, CancellationToken cancellationToken = default)
        => await _dbContext.DeltaTemperatures.Where(x => x.ReadingModuleId == readingModuleId).ToListAsync(cancellationToken);

    public async Task<DeltaTemperature> Add(int readingModuleId)
    {
        var actualTemperature = await _dbContext.Temperatures.Where(x => x.ReadingModuleId == readingModuleId).OrderByDescending(x => x.Id).Select(s => new ushort?[] { s.sensor1, s.sensor2 }).FirstAsync();

        var yesterday = DateTime.Today.AddDays(-1);
        string HourOfReading = _dbContext.Settings.Select(setting => setting.HourOfReading).ToString();
        var dayBeforeTemperature = await _dbContext.Temperatures.Where(x => x.CreatedAt == yesterday.AddHours(double.Parse(HourOfReading)) & x.ReadingModuleId == readingModuleId).Select(s => new ushort?[] { s.sensor1, s.sensor2 }).FirstAsync();

        ushort?[] valuesOfDelta = new ushort?[100];
        for (int i = 0; i < 100; i++)
        {
            var result = actualTemperature[i] - dayBeforeTemperature[i];

            valuesOfDelta[i] = (ushort?)result;
        }

        var deltaTemperature = new DeltaTemperature
        {
            ReadingModuleId = readingModuleId,
            sensor1 = valuesOfDelta[0],
            sensor2 = valuesOfDelta[1],
            sensor3 = valuesOfDelta[2],
            sensor4 = valuesOfDelta[3],
            sensor5 = valuesOfDelta[4],
            sensor6 = valuesOfDelta[5],
            sensor7 = valuesOfDelta[6],
            sensor8 = valuesOfDelta[7],
            sensor9 = valuesOfDelta[8],
            sensor10 = valuesOfDelta[9],
            sensor11 = valuesOfDelta[10],
            sensor12 = valuesOfDelta[11],
            sensor13 = valuesOfDelta[12],
            sensor14 = valuesOfDelta[13],
            sensor15 = valuesOfDelta[14],
            sensor16 = valuesOfDelta[15],
            sensor17 = valuesOfDelta[16],
            sensor18 = valuesOfDelta[17],
            sensor19 = valuesOfDelta[18],
            sensor20 = valuesOfDelta[19],
            sensor21 = valuesOfDelta[20],
            sensor22 = valuesOfDelta[21],
            sensor23 = valuesOfDelta[22],
            sensor24 = valuesOfDelta[23],
            sensor25 = valuesOfDelta[24],
            sensor26 = valuesOfDelta[25],
            sensor27 = valuesOfDelta[26],
            sensor28 = valuesOfDelta[27],
            sensor29 = valuesOfDelta[28],
            sensor30 = valuesOfDelta[29],
            sensor31 = valuesOfDelta[30],
            sensor32 = valuesOfDelta[31],
            sensor33 = valuesOfDelta[32],
            sensor34 = valuesOfDelta[33],
            sensor35 = valuesOfDelta[34],
            sensor36 = valuesOfDelta[35],
            sensor37 = valuesOfDelta[36],
            sensor38 = valuesOfDelta[37],
            sensor39 = valuesOfDelta[38],
            sensor40 = valuesOfDelta[39],
            sensor41 = valuesOfDelta[40],
            sensor42 = valuesOfDelta[41],
            sensor43 = valuesOfDelta[42],
            sensor44 = valuesOfDelta[43],
            sensor45 = valuesOfDelta[44],
            sensor46 = valuesOfDelta[45],
            sensor47 = valuesOfDelta[46],
            sensor48 = valuesOfDelta[47],
            sensor49 = valuesOfDelta[48],
            sensor50 = valuesOfDelta[49],
            sensor51 = valuesOfDelta[50],
            sensor52 = valuesOfDelta[51],
            sensor53 = valuesOfDelta[52],
            sensor54 = valuesOfDelta[53],
            sensor55 = valuesOfDelta[54],
            sensor56 = valuesOfDelta[55],
            sensor57 = valuesOfDelta[56],
            sensor58 = valuesOfDelta[57],
            sensor59 = valuesOfDelta[58],
            sensor60 = valuesOfDelta[59],
            sensor61 = valuesOfDelta[60],
            sensor62 = valuesOfDelta[61],
            sensor63 = valuesOfDelta[62],
            sensor64 = valuesOfDelta[63],
            sensor65 = valuesOfDelta[64],
            sensor66 = valuesOfDelta[65],
            sensor67 = valuesOfDelta[66],
            sensor68 = valuesOfDelta[67],
            sensor69 = valuesOfDelta[68],
            sensor70 = valuesOfDelta[69],
            sensor71 = valuesOfDelta[70],
            sensor72 = valuesOfDelta[71],
            sensor73 = valuesOfDelta[72],
            sensor74 = valuesOfDelta[73],
            sensor75 = valuesOfDelta[74],
            sensor76 = valuesOfDelta[75],
            sensor77 = valuesOfDelta[76],
            sensor78 = valuesOfDelta[77],
            sensor79 = valuesOfDelta[78],
            sensor80 = valuesOfDelta[79],
            sensor81 = valuesOfDelta[80],
            sensor82 = valuesOfDelta[81],
            sensor83 = valuesOfDelta[82],
            sensor84 = valuesOfDelta[83],
            sensor85 = valuesOfDelta[84],
            sensor86 = valuesOfDelta[85],
            sensor87 = valuesOfDelta[86],
            sensor88 = valuesOfDelta[87],
            sensor89 = valuesOfDelta[88],
            sensor90 = valuesOfDelta[89],
            sensor91 = valuesOfDelta[90],
            sensor92 = valuesOfDelta[91],
            sensor93 = valuesOfDelta[92],
            sensor94 = valuesOfDelta[93],
            sensor95 = valuesOfDelta[94],
            sensor96 = valuesOfDelta[95],
            sensor97 = valuesOfDelta[96],
            sensor98 = valuesOfDelta[97],
            sensor99 = valuesOfDelta[98],
            sensor100 = valuesOfDelta[99],
        };

        _dbContext.DeltaTemperatures.Add(deltaTemperature);

        return deltaTemperature;
    }
}
