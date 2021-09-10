using System.IO;
using System.Text;
using System.Threading.Tasks;

using Bet.AspNetCore.Shopify.Middleware.Hmac;

using Microsoft.AspNetCore.Mvc;

namespace ShopifyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        [Route("Cart")]
        [HmacValidation]

        // https://localhost:5001/api​/Webhook​/Cart
        public async Task<string> GetCart()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }

        [HttpPost]
        [Route("Order")]

        // https://localhost:5001/api​/Webhook​/Order
        public async Task<string> GetOrder()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }
    }
}
