using System.Collections;
using System.Collections.Generic;

namespace Core.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserID { get; }

        bool IsAuthenticated { get; }
    }

    public interface IMetroFareService
    {
        decimal GetDiscountedFare(string cardNumber, decimal amount);
       
    }
}