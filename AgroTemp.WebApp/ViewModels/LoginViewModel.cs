using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij nazwę użytkownika.")]
    public string? Login { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij hasło.")]
    public string? Password { get; set; }
}
