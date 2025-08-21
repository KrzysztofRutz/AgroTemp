using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class HourOfReadingViewModel
{
    [Required(ErrorMessage ="Uzupełnij wartość godziny odczytu.")]
    public string Value { get; set; } 
}
