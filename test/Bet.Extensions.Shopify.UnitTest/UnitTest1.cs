using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Queries;

using Xunit;

namespace Bet.Extensions.Shopify.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var product = new ProductQuery { Limit = 1, PageInfo = "zsdsfsjkljlkhlkh" };

            var kvb = product.ToKeyValuePair();

            var url = kvb.CompileRequestUri("/products");

            Assert.NotEmpty(url);

            Assert.NotNull(kvb);
        }

        [Fact]
        public async Task TestJsonContent()
        {
            var product = new Product
            {
                Handle = "test-handle",
                Images = new List<ProductImage> { new ProductImage { Src = "https://image.io" } }
            };

            var content = new JsonContent(new { product = product });
            var uft8 = await content.ReadAsByteArrayAsync();

            var json = Encoding.UTF8.GetString(uft8);

            Assert.NotNull(json);
        }
    }
}
