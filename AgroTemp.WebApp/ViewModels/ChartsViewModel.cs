using AgroTemp.WebApp.ViewModels.Validations;
using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class ChartsViewModel
{
    [Required(ErrorMessage = "Wybierz poprawną nazwę zbiornika.")]
    public int SiloId { get; set; } = new();

    [Required(ErrorMessage = "Wybierz poprawną nazwę sondy.")]
    public int ProbeWithDetailsId { get; set; } = new();

    [Required(ErrorMessage = "Wybierz datę początkową.")]
    [DateLessThan(nameof(EndAt), ErrorMessage = "Data początkowa musi być wcześniejsza niż data końcowa.")]
    [DataType(DataType.Date)]
    public DateTime StartAt { get; set; } = DateTime.Now.AddDays(-7);

    [Required(ErrorMessage = "Wybierz datę końcową.")]
    [DateGreaterThan(nameof(StartAt), ErrorMessage = "Data końcowa musi być późniejsza niż data początkowa.")]
    [DataType(DataType.Date)]
    public DateTime EndAt { get; set; } = DateTime.Now;
}
