using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using Newtonsoft.Json;
using System.Web;

namespace AgroTemp.WebApp.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync("api/users", cancellationToken);

        if (!result.IsSuccessStatusCode)
            return null;

        string content = await result.Content.ReadAsStringAsync();

        var users = JsonConvert.DeserializeObject<IEnumerable<User>>(content);

        return users;
    }

    public async Task<User> GetByLoginAndPasswordAsync(string login, string password, CancellationToken cancellationToken = default)
    {
        var loginEncode = HttpUtility.UrlEncode(login);
        var passwdEncode = HttpUtility.UrlEncode(password);

        var result = await _httpClient.GetAsync($"api/users/getByLoginAndPassword?login={loginEncode}&password={passwdEncode}", cancellationToken);       

        if (!result.IsSuccessStatusCode)
            return null;

        string content = await result.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<User>(content);

        return user;
    }

    public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetAsync($"api/users/{id}", cancellationToken);

        if (!result.IsSuccessStatusCode)
            return null;

        string content = await result.Content.ReadAsStringAsync();

        var user = JsonConvert.DeserializeObject<User>(content);

        return user;
    }

    public async Task UpdateLoginAsync(int id, string login)
    {
        var patchValue = new 
        {
            Id = id,
            Login = login 
        };

        var result =  await _httpClient.PatchAsJsonAsync("api/users/login", patchValue);

        if (!result.IsSuccessStatusCode)
        {
            var message = await result.Content.ReadAsStringAsync();   
            throw new Exception(message);
        }
    }

    public async Task UpdatePasswordAsync(int id, string password)
    {
        var patchValue = new
        {
            Id = id,
            Password = password
        };

        var result = await _httpClient.PatchAsJsonAsync("api/users/password", patchValue);

        if (!result.IsSuccessStatusCode)
        {
            var message = await result.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }

    public async Task UpdateUserParametersAsync(User user)
    {
        var patchValue = new
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            TypeOfUser = user.TypeOfUser
        };

        var result = await _httpClient.PatchAsJsonAsync("api/users/UserParameters", patchValue);

        if (!result.IsSuccessStatusCode)
        {
            var message = await result.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
    }
}
