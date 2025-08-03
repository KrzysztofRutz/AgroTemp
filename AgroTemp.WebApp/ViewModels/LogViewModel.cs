using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class LogViewModel
{
    [Required(ErrorMessage = "Uzupełnij login.")]
    public string Login { get; set; }
    public string Password { get; set; }
}
