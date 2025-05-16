using MigrationSystem22.Models;
using MigrationSystem22.Services;

namespace MigrationSystem22.Controllers;

public class UserController
{
    private readonly UserService _userService;

    public UserController()
    {
        _userService = new UserService();
    }

    public bool SaveUser(User user, out string error)
    {
        try
        {
            _userService.SaveUser(user);
            error = string.Empty;
            return true;
        }
        catch (Exception ex)
        {
            error = ex.InnerException?.Message ?? ex.Message;
            return false;
        }
    }

}