using Core.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserID = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserID != null;
        }

        public string UserID { get; }

        public bool IsAuthenticated { get; }
    }

    public class FareMatrix : IMetroFareService
    {
        public decimal GetDiscountedFare(string cardNumber, decimal amount)
        {
            throw new System.NotImplementedException();
        }
    }
}