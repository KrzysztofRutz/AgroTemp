using AgroTemp.WebApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class FrequencyOfReadingViewModel
{
    [Required(ErrorMessage = "Uzupełnij wartość częstotliwości odczytu.")]
    [EnumDataType(typeof(FrequencyOfReading), ErrorMessage = "Częstotliwość odczytu musi być jedną z poniższych wartości.")]
    public FrequencyOfReading Value { get; set; } 
}
