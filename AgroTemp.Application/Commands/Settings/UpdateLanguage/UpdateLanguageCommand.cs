using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;

namespace AgroTemp.Application.Commands.Settings.UpdateLanguage;

public class UpdateLanguageCommand : ICommand
{
    public string Language { get; set; }
}
