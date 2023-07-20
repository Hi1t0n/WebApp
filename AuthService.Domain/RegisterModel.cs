using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain;

public class RegisterModel
{
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Email { get; set; } = "";

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string BirthdayDate { get; set; } = "";
}