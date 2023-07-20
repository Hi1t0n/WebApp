namespace AuthService.Domain;

public interface IAuthManager
{
    /// <summary>
    ///     Получение всех пользователей
    /// </summary>
    /// <returns>Список всех пользователей</returns>
    List<User> GetAll();

    /// <summary>
    ///     Полученние анных пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Данные пользователя с указанным id</returns>
    User? GetById(long id);

    /// <summary>
    /// Поиск пользователя по логину
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    User? FindUserByLogin(string login);


    public bool VerifyPassword(User user, string password);

    /// <summary>
    ///     Добавление пользователя
    /// </summary>
    /// <param name="user"> Данные пользователя</param>
    /// <returns>Данные добавленного пользователя</returns>
    User CreateUser(User user);

    /// <summary>
    ///     Обновление данных пользователя
    /// </summary>
    /// <param name="user">Данные пользователя</param>
    /// <returns>Данные польователя после обновления</returns>
    User? UpdateUser(User user);

    /// <summary>
    ///     Удаление пользователя
    /// </summary>
    /// <param name="id">id удаляемого пользователя</param>
    /// <returns>Данные удаляемого пользователя</returns>
    User? DeleteUser(long id);

    User? Authenticate(string Login, string Password);

    User? Register(RegisterModel model);

}