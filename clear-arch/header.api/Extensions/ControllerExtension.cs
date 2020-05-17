namespace api.Extensions
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="ControllerExtension" />.
    /// </summary>
    public static class ControllerExtension
    {
        /// <summary>
        /// The Base64Encode.
        /// </summary>
        /// <param name="controller">The controller<see cref="ControllerBase"/>.</param>
        /// <param name="plainText">The plainText<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string Base64Encode(this ControllerBase controller, string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// The Base64Decode.
        /// </summary>
        /// <param name="controller">The controller<see cref="ControllerBase"/>.</param>
        /// <param name="base64EncodedData">The base64EncodedData<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string Base64Decode(this ControllerBase controller, string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}