using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class TimeRangeViewModel
{
    [DataType(DataType.Date)]
    public DateTime StartAt { get; set; } = DateTime.Now.AddDays(-7);

    [DataType(DataType.Date)]
    public DateTime EndAt { get; set; } = DateTime.Now;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartAt != null && EndAt != null)
        {
            if (EndAt < StartAt)
            {
                yield return new ValidationResult(
                    "Data końcowa nie może być wcześniejsza niż data początkowa.",
                    new[] { nameof(EndAt) });
            }
        }
    }
}
