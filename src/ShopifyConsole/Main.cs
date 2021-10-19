using Bet.Extensions.Shopify.Clients;
using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Fulfillments;
using Bet.Extensions.Shopify.Models.Inventory;
using Bet.Extensions.Shopify.Models.Metafields;
using Bet.Extensions.Shopify.Models.Orders;
using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Models.Queries;
using Bet.Extensions.Shopify.Models.Queries.Fulfillments;
using Bet.Extensions.Shopify.Models.Queries.Metafields;
using Bet.Extensions.Shopify.Models.Queries.Orders;
using Bet.Extensions.Shopify.Models.Queries.Products;

namespace ShopifyConsole
{
    public class Main : IMain
    {
        private readonly ILogger<Main> _logger;
        private readonly IShopifyTypedClient<Product, ProductQuery, ProductCountQuery> _productClient;
        private readonly IShopifyTypedClient<Metafield, MetafieldQuery, NoOpQuery> _metafieldClient;
        private readonly IShopifyTypedClient<Transaction, NoOpQuery, NoOpQuery> _transactionClient;
        private readonly IShopifyTypedClient<Order, OrderQuery, OrderCountQuery> _orderClient;
        private readonly IShopifyTypedClient<Fulfillment, FulfillmentQuery, FulfillmentCountQuery> _fulfillmentClient;
        private readonly IShopifyTypedClient<Location, NoOpQuery, NoOpQuery> _locationClient;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public Main(
            IShopifyTypedClient<Product, ProductQuery, ProductCountQuery> productClient,
            IShopifyTypedClient<Metafield, MetafieldQuery, NoOpQuery> metafieldClient,
            IShopifyTypedClient<Transaction, NoOpQuery, NoOpQuery> transactionClient,
            IShopifyTypedClient<Order, OrderQuery, OrderCountQuery> orderClient,
            IShopifyTypedClient<Fulfillment, FulfillmentQuery, FulfillmentCountQuery> fulfillmentClient,
            IShopifyTypedClient<Location, NoOpQuery, NoOpQuery> locationClient,
            IHostApplicationLifetime applicationLifetime,
            IConfiguration configuration,
            ILogger<Main> logger)
        {
            _productClient = productClient ?? throw new ArgumentNullException(nameof(productClient));
            _metafieldClient = metafieldClient;
            _transactionClient = transactionClient ?? throw new ArgumentNullException(nameof(transactionClient));
            _orderClient = orderClient;
            _fulfillmentClient = fulfillmentClient;
            _locationClient = locationClient;
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IConfiguration Configuration { get; set; }

        public async Task<int> RunAsync()
        {
            _logger.LogInformation("Main executed");

            // use this token for stopping the services
            var cancellationToken = _applicationLifetime.ApplicationStopping;
            cancellationToken.ThrowIfCancellationRequested();

            // var order = await _orderClient.GetAsync(
            //    $"orders/{4063400525997}.json",
            //    new OrderQuery
            //    {
            //        Fields = new List<string> { "tags", "id" }
            //    },
            //    rootElement: "order",
            //    cancellationToken: cancellationToken);

            // if (order?.Tags == null)
            // {
            //    order.Tags = "test";
            // }
            // else
            // {
            //    order.Tags += ",test";
            // }

            // var uOrder = await _orderClient.UpdateAsync(
            //    $"orders/{order.Id}.json",
            //    new { order = order },
            //    rootElement: "order",
            //    cancellationToken: cancellationToken);
            var locations = await _locationClient.ListAsync("locations.json", rootElement: "locations", cancellationToken: cancellationToken);

            var oId = 4063391252653;

            var fulFillData = new Fulfillment
            {
                OrderId = oId,
                TrackingCompany = "fedex",
                TrackingNumber = "23-223-979799998",
                LocationId = locations?.Payload?.FirstOrDefault().Id,
                NotifyCustomer = true
            };

            var uFulFillData = await _fulfillmentClient.CreateAsync(
                $"orders/{oId}/fulfillments.json",
                new { fulfillment = fulFillData },
                rootElement: "fulfillment",
                cancellationToken: cancellationToken);

            var transactions = await _transactionClient.ListAsync(
                       $"orders/{4063710019757}/transactions.json",
                       rootElement: "transactions",
                       cancellationToken: cancellationToken);

            var shopMetadata = await _metafieldClient.ListAsync("metafields.json", "metafields", cancellationToken: cancellationToken);

            var productQuery = new ProductQuery
            {
                Limit = 150,
                Vendor = "Husky"
            };

            var productCount = await _productClient.CountAsync(
                "products/count.json",
                "count",
                productQuery,
                cancellationToken);

            var products = await _productClient.ListAllAsync(
                "products.json",
                "products",
                productQuery,
                cancellationToken);

            var createProduct = await _productClient.CreateAsync(
                "products.json",
                new { product = CreateProduct() },
                "product",
                cancellationToken);

            _logger.LogInformation("Create Id: {created}", createProduct.Id);

            var getProduct = await _productClient.GetAsync(
                $"products/{createProduct.Id}.json",
                rootElement: "product",
                cancellationToken: cancellationToken);

            _logger.LogInformation("Get Id: {created}", getProduct.Id);

            var updateProduct = await _productClient.UpdateAsync(
                $"products/{getProduct.Id}.json",
                new { product = UpdateProduct(getProduct) },
                "product",
                cancellationToken);

            _logger.LogInformation("Upated Id: {created}", updateProduct.Id);

            await _productClient.DeleteAsync($"products/{updateProduct.Id}.json", cancellationToken);

            return 0;
        }

        private static Product UpdateProduct(Product product)
        {
            product.Options = new List<ProductOption>
            {
                new ProductOption
                {
                    Name = "Lock Code",
                    Values = new[] { "1", "2" }
                }
            };

            product.Metafields = new List<MetaField>
            {
                new MetaField
                {
                    Namespace = "global",
                    Key = "keyblank",
                    Value = "001",
                    ValueType = "string"
                },

                new MetaField
                {
                    Namespace = "global",
                    Key = "keycodes",
                    Value = "001-100",
                    ValueType = "string"
                },
            };

            return product;
        }

        private static Product CreateProduct()
        {
            return new Product
            {
                Title = "Messianic Menorah",
                BodyHtml = "<p>Messianic Menorah. Made of high quality Brass. Seven Branch Menorah. 25cm of Height.</p>",
                SeoTitle = "SEO TEST TITLE",
                SeoDescription = "SEO Description",
                Status = "draft",
                Images = new List<ProductImage>
                {
                    new ProductImage
                    {
                        Src = "https://sep.yimg.com/ay/yhst-38188218237026/messianic-menorah-10.jpg"
                    }
                },
                Metafields = new List<MetaField>
                    {
                        new MetaField
                        {
                            Namespace = "global",
                            Key = "harmonized_system_code",
                            ValueType = "string",
                            Value = "830170"
                        }
                    }
            };
        }
    }
}
