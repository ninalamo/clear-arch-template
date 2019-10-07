using domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Extensions
{
    public static class ControllerExtension
    {


        public static void GiveCredit(this ControllerBase controller, ICreditable model, bool isEdit = false)
        {

            if (controller.User == null) return;
            if (controller.User.Identity.IsAuthenticated)
            {
                if (!isEdit)
                {
                    model.CreatedBy = controller.User.Identity.Name;
                }
                model.ModifiedBy = controller.User.Identity.Name;
            }
        }

        public static string Base64Encode(this ControllerBase controller, string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this ControllerBase controller, string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }



    }
}
