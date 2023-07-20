using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain;

public class User
{
    /// <summary>
    ///     ID
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    ///     Логин
    /// </summary>
    public string Login { get; set; } = "";

    /// <summary>
    ///     Пароль
    /// </summary>
    public string Password { get; set; } = "";

    /// <summary>
    ///     Имя
    /// </summary>
    public string FirstName { get; set; } = "";

    /// <summary>
    ///     Фамилия
    /// </summary>
    public string LastName { get; set; } = "";

    /// <summary>
    ///     Почта
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    ///     Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; } = "";

    /// <summary>
    ///     Дата рождения
    /// </summary>
    public string BirthdayDate { get; set; } = "";

    public string Token { get; set; } = "";
}
