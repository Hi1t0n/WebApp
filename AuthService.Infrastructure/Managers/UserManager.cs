using AuthService.Domain;
using AuthService.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Security.Cryptography;

using BCryptNet = BCrypt.Net.BCrypt;
//using AuthService.Infrastructure.Helpers;

namespace AuthService.Infrastructure.Managers;

// Реализация интерфейса IAuthManager

public class AuthManager : IAuthManager
{
    private readonly UserContext _UserContext;
    public AuthManager(UserContext context)
    {
        _UserContext = context;
    }

    // Получение всех пользователей
    public List<User> GetAll()
    {
        return _UserContext.Users.ToList();
    }

    public User? Authenticate (string Login, string Password)
    {
        var user = _UserContext.Users.FirstOrDefault(u => u.Login == Login && u.Password == HashPassword(Password));
        if (user is null) { return null; }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("my_secret_key777");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,user.Login)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        user.Token = tokenHandler.WriteToken(token);

        user.Password = null;

        return user;
    }

    public User? Register(RegisterModel model)
    {
        if(_UserContext.Users.Any(u=>u.Login == model.Login)) { return null;}

        var user = new User
        {
            Login = model.Login,
            Password = HashPassword(model.Password),
            BirthdayDate = model.BirthdayDate,
            Email = model.Email,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };

        _UserContext.Users.Add(user);
        _UserContext.SaveChanges();
        return user;
    }

    public User? GetById(long id)
    {
        return _UserContext.Users.FirstOrDefault(x => x.Id == id);
    } // Получение данных пользователя по id

    //Поиск по логину при регистрации
    public User? FindUserByLogin(string login)
    {
        return _UserContext.Users.FirstOrDefault(x => x.Login == login);
    }

    //Сравнение пароля при авторизации
    public bool VerifyPassword(User user, string password)
    {
        return BCryptNet.Verify(password, user.Password);
    }

    //Добавление пользователя
    
    public User CreateUser(User user)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x=>x.Login==user.Login);
        if (existingUser != null) { throw new Exception("Пользователь с таким именем уже существует"); }
        
        user.Password = HashPassword(user.Password);

        var UserData = _UserContext.Users.Add(user);

        _UserContext.SaveChanges();

        return UserData.Entity;
    }

    // Обновление данных пользователя
    public User? UpdateUser(User user)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x => x.Id == user.Id);

        if (existingUser is null) return null;

        existingUser.Login = user.Login;
        existingUser.Password = user.Password;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.Email = user.Email;
        existingUser.BirthdayDate = user.BirthdayDate;

        var UserData = _UserContext.Update(user);
        _UserContext.SaveChanges();
        return UserData.Entity;
    }

    // Удаление пользователя

    public User? DeleteUser(long id)
    {
        var existingUser = _UserContext.Users.FirstOrDefault(x => x.Id == id);

        if (existingUser is null) return null;

        var UserData = _UserContext.Remove(existingUser);
        _UserContext.SaveChanges();
        return UserData.Entity;
    }

    //
    
    //
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}

