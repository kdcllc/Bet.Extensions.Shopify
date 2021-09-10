using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Clients;
using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Metafields;
using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Models.Queries;
using Bet.Extensions.Shopify.Models.Queries.Metafields;
using Bet.Extensions.Shopify.Models.Queries.Products;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ShopifyConsole
{
    public class Main : IMain
    {
        private readonly ILogger<Main> _logger;
        private readonly IShopifyTypedClient<Product, ProductQuery, ProductCountQuery> _productClient;
        private readonly IShopifyTypedClient<Metafield, MetafieldQuery, NoOpQurey> _metafield;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public Main(
            IShopifyTypedClient<Product, ProductQuery, ProductCountQuery> productClient,
            IShopifyTypedClient<Metafield, MetafieldQuery, NoOpQurey> metafield,
            IHostApplicationLifetime applicationLifetime,
            IConfiguration configuration,
            ILogger<Main> logger)
        {
            _productClient = productClient ?? throw new ArgumentNullException(nameof(productClient));
            _metafield = metafield;
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

            var shopMetadata = await _metafield.ListAsync("metafields.json", "metafields", cancellationToken: cancellationToken);

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
