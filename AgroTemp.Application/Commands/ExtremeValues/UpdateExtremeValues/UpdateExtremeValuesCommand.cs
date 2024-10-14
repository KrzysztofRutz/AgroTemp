using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Commands.ExtremeValues.UpdateExtremeValues;

public class UpdateExtremeValuesCommand : ICommand<ExtremeValuesDto> 
{
    public int SiloId { get; set; }
    public int? MaxTemperature { get; set; }
    public int? MinTemperature { get; set; }
    public int? MaxDeltaTemperature { get; set; }   
}
