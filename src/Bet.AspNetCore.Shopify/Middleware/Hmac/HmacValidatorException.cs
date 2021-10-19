using System;

namespace Bet.AspNetCore.Shopify.Middleware.Hmac
{
    public class HmacValidatorException : Exception
    {
        public HmacValidatorException() : base()
        {
        }

        public HmacValidatorException(string message) : base(message)
        {
        }

        public HmacValidatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
