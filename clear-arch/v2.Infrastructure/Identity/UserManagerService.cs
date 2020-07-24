using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly AppSettings appSettings;

        public UserManagerService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<AppSettings> options)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            appSettings = options.Value;
        }

        public async Task<(Result Result, string UserId, string Code)> CreateUserAsync(string userName, string password)
        {
            var confirmationCode = "";

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                confirmationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }

            return (result.ToApplicationResult(), user.Id, confirmationCode);
        }

        public async Task<Result> AddToRoleAsync(string email, string role)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null) throw new NotFoundException(nameof(ApplicationUser), email);

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.ToApplicationResult();
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<string> UserLoginAsync(string userName, string password)
        {
            string errorMsg = string.Empty;
            try
            {
                string token = string.Empty;

                var user = await _userManager.FindByNameAsync(userName);

                var canLogin = await _signinManager.CheckPasswordSignInAsync(user, password, false);

                //if able to login - meaning used user + password successfully
                if (canLogin.Succeeded)
                {
                    //create claims based on roles / and application permission
                    token = CreateToken(user, out List<Claim> claims);
                    return token;
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return string.Empty;
        }

        public async Task<string> GetPasswordResetToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return string.Empty;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }

        public async Task<Result> ResetPassword(string email, string password, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new Exception("Invalid email or username.");

            var result = await _userManager.ResetPasswordAsync(user, token, password);

            return result.ToApplicationResult();
        }

        private string CreateToken(ApplicationUser user, out List<Claim> claims)
        {
            var roles = _userManager.GetRolesAsync(user).Result;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //create claims based on roles / and application permission
            claims = new List<Claim>();

            //add role-based claims
            claims.AddRange(RoleBaseClaims(user, roles.ToArray()).AsEnumerable());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private List<Claim> RoleBaseClaims(ApplicationUser user, string[] roles)
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.Name, user.Email),
                };

            if (roles.Any())
                claims.AddRange(roles.Select(a => new Claim(ClaimTypes.Role, a)));

            return claims;
        }

        public async Task<Result> AddClaims(string email, string[] claims)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new Exception("User not found.");

            var result = await _userManager.AddClaimsAsync(user, claims.Select(i => new Claim("USER", i.ToUpper())));

            return result.ToApplicationResult();
        }

        public async Task<Result> ConfirmEmail(string code, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) throw new Exception("User not found.");

            user.LockoutEnabled = false;
            await _userManager.UpdateAsync(user);
            var result = await _userManager.ConfirmEmailAsync(user, code);

            return result.ToApplicationResult();
        }
    }
}