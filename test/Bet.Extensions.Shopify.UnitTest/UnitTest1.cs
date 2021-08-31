using System;

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
    }
}
