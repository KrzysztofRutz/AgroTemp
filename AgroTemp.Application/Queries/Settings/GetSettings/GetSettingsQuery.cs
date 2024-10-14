using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Queries.Settings.GetSettings;

public record GetSettingsQuery : IQuery<SettingsDto>
{
}
