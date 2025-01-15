// In ./src/Services/IUserService.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Models;

public interface IUserService
{
    Task<bool> RegisterUserAsync(RegisterUserDto model);
    Task<string> LoginAsync(LoginDto model);
    Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
}

// In ./src/Services/UserService.cs
public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public UserService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<bool> RegisterUserAsync(RegisterUserDto model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        return result.Succeeded;
    }

    public async Task<string> LoginAsync(LoginDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            // Generate and return JWT token or handle authentication as needed
            return "Authentication successful";
        }
        return null;
    }

    public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result.Succeeded;
    }
}