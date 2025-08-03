using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class ExtremeValuesViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij graniczną maksymalną wartość temperatury.")]
    [Range(-50, 50, ErrorMessage = "Wartość jest poza zakresem. Dopuszczalny zakres: -50°C - 50°C")]
    public int MaxTemperature { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij graniczną minimalną wartość temperatury.")]
    [Range(-50, 50, ErrorMessage = "Wartość jest poza zakresem. Dopuszczalny zakres: -50°C - 50°C")]
    public int MinTemperature { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij graniczną maksymalną wartość przyrostu temperatury ΔT.")]
    [Range(-50, 50, ErrorMessage = "Wartość jest poza zakresem. Dopuszczalny zakres: -50°C - 50°C")]
    public int MaxDeltaTemperature { get; set; }
}
