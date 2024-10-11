using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Entities;
using AutoMapper;

namespace AgroTemp.Application.Configuration.Mappings;

public class TemperatureForOneProbeMappingProfile : Profile
{
    public TemperatureForOneProbeMappingProfile()
    {
		CreateMap<Temperature, TemperatureForOneProbeDto>()
			.ForMember(member => member.ListOfTemperatures, conf => conf.MapFrom(src =>
				new List<ushort?>
				{
					src.sensor1, src.sensor2, src.sensor3, src.sensor4, src.sensor5, src.sensor6, src.sensor7, src.sensor8, src.sensor9, src.sensor10, src.sensor11, src.sensor12, src.sensor13, src.sensor14, src.sensor15, src.sensor16, src.sensor17, src.sensor18, src.sensor19, src.sensor20, src.sensor21, src.sensor22, src.sensor23, src.sensor24, src.sensor25, src.sensor26, src.sensor27, src.sensor28, src.sensor29, src.sensor30, src.sensor41, src.sensor42, src.sensor43, src.sensor44, src.sensor45, src.sensor46, src.sensor47, src.sensor48, src.sensor49, src.sensor50, src.sensor51, src.sensor52, src.sensor53, src.sensor54, src.sensor55, src.sensor56, src.sensor57, src.sensor58, src.sensor59, src.sensor60, src.sensor61, src.sensor62, src.sensor63, src.sensor64, src.sensor65, src.sensor66, src.sensor67, src.sensor68, src.sensor69, src.sensor70, src.sensor71, src.sensor72, src.sensor73, src.sensor74, src.sensor75, src.sensor76, src.sensor77, src.sensor78, src.sensor79, src.sensor80, src.sensor81, src.sensor82, src.sensor83, src.sensor84, src.sensor85, src.sensor86, src.sensor87, src.sensor88, src.sensor89, src.sensor90, src.sensor91, src.sensor92, src.sensor93, src.sensor94, src.sensor95, src.sensor96, src.sensor97, src.sensor98, src.sensor99, src.sensor100
				}
				//.Where(v => v.HasValue)
				//.Select(v => v.Value)
				.ToList()));
	}
}
