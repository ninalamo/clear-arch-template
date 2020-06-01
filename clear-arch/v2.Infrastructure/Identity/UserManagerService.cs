using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
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


        public UserManagerService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
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

        public async Task<(Result Result, string token)> UserLoginAsync(string userName, string password)
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
                    return (Result.Success(), token);
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            return (Result.Failure(new[] { "Unable to login", errorMsg }), string.Empty);
        }


        public async Task<(Result, string)> GetPasswordResetToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return (Result.Failure(new[] { "Invalid email" }), string.Empty);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return (Result.Success(), token);
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
                Expires = DateTime.UtcNow.AddMinutes(10D),
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



    }
}