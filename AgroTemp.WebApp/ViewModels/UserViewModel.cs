using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class UserViewModel
{
    [Required(ErrorMessage = "Uzupełnij imię.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Uzupełnij nazwisko.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Uzupełnij e-mail.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Uzupełnij typ użytkownika.")]
    public string TypeOfUser { get; set; }
}
