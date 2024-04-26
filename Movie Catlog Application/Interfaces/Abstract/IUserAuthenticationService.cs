using Movie_Catlog_Application.DTOs.User;

namespace Movie_Catlog_Application.Interfaces.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(Login model);

        Task<Status> RegisterAsync(Register model);
        Task LogoutAsync();
    }
}
