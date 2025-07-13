using System.ComponentModel.DataAnnotations;

namespace AgroTemp.WebApp.ViewModels;

public class MyProfileViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij imię.")]
    public string FirstName { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij nazwisko.")]
    public string LastName { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij email.")]
    public string Email { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Uzupełnij typ użytkownika.")]
    public string Role { get; set; }

}
