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
        {
            return null;
        }

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
        {
            return null;
        }

        string content = await result.Content.ReadAsStringAsync();
        var user = JsonConvert.DeserializeObject<User>(content);

        return user;
    }

    public async Task UpdateAsync(User user)
    {
        var result =  await _httpClient.PutAsJsonAsync("api/users", user);

        if (!result.IsSuccessStatusCode)
        {
            var message = await result.Content.ReadAsStringAsync();
     
            throw new Exception(message);
        }
    }
}
