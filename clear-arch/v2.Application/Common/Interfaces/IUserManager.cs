using System.Threading.Tasks;
using Core.Application.Common.Models;

namespace Core.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string token)> UserLoginAsync(string userName, string password); 
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
        Task<(Result, string)> GetPasswordResetToken(string email);
        Task<Result> ResetPassword(string email, string password, string token);
        Task<Result> AddToRoleAsync(string email, string role);
        
    }
}