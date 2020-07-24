using System.Threading.Tasks;
using Core.Application.Common.Models;

namespace Core.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<string> UserLoginAsync(string userName, string password);

        Task<(Result Result, string UserId, string Code)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<string> GetPasswordResetToken(string email);

        Task<Result> ResetPassword(string email, string password, string token);

        Task<Result> AddToRoleAsync(string email, string role);

        Task<Result> AddClaims(string email, string[] claims);

        Task<Result> ConfirmEmail(string code, string userId);
    }
}