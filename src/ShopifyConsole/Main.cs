using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Clients;
using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Queries;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShopifyConsole
{
    public class Main : IMain
    {
        private readonly ILogger<Main> _logger;
        private readonly IInventoryClient _inventoryClient;
        private readonly IProductClient _productClient;
        private readonly IShopifyClient _shopifyService;
        private readonly ShopifyOptions _options;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public IConfiguration Configuration { get; set; }

        public Main(
            IInventoryClient inventoryClient,
            IProductClient productClient,
            IShopifyClient shopifyService,
            IOptions<ShopifyOptions> options,
            IHostApplicationLifetime applicationLifetime,
            IConfiguration configuration,
            ILogger<Main> logger)
        {
            _inventoryClient = inventoryClient;
            _productClient = productClient;
            _shopifyService = shopifyService;
            _options = options.Value;

            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> RunAsync()
        {
            _logger.LogInformation("Main executed");

            // use this token for stopping the services
            var cancellationToken = _applicationLifetime.ApplicationStopping;
            cancellationToken.ThrowIfCancellationRequested();

            // var invt = await _inventory.GetLocationsAsync(cancellationToken);

            var newProd = new Product
            {
                Title = "sample title",
                BodyHtml = "<p>Test Product</p>",
                SeoTitle = "SEO TEST TITLE",
                SeoDescription = "SEO Description",
                Status = "draft",
                Images = new List<ProductImage> { new ProductImage { Src = "https://easykeys.com/Images/Manufacturers/are_logo.gif" } },
                Metafields = new List<MetaField>
                    {
                        new MetaField { Namespace = "global",
                                        Key = "harmonized_system_code",
                                        ValueType = "string",
                                        Value = "830170" }
                    }
            };

            var pc = await _productClient.CreateAsync(newProd, cancellationToken);

            // var p = await _productClient.GetAsync(7057619386530, new FieldsQuery(), cancellationToken);

            pc.Options = new List<ProductOption> { new ProductOption { Name = "Lock Code", Values = new[] { "1", "2" } } };
            pc.Metafields = new List<MetaField>
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

            var up = await _productClient.UpdateAsync(pc, cancellationToken);

            await _productClient.DeleteAsync(up.Id.GetValueOrDefault(), cancellationToken);

            var productQuery = new ProductQuery
            {
                Limit = 150,
                Vendor = "Husky"
            };

            var ps = await _productClient.GetAsync(7052747014306, new FieldsQuery(), cancellationToken);

            var productsCount = await _productClient.CountAsync(productQuery, cancellationToken);
            var products = await _productClient.ListAllAsync(productQuery, cancellationToken);

            return 0;
        }
    }
}
