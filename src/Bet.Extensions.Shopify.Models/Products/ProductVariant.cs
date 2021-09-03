using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Products
{
    /// <summary>
    /// <para>The Shopify API lets you do the following with the Product Variant resource. More detailed versions of these general actions may be available:</para>
    /// <para>
    /// GET /admin/api/2021-07/products/{product_id}/variants.json
    /// Retrieves a list of product variants.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/products/{product_id}/variants/count.json
    /// Receive a count of all Product Variants.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/variants/{variant_id}.json
    /// Receive a single Product Variant.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/products/{product_id}/variants.json
    /// Create a new Product Variant.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/variants/{variant_id}.json
    /// Modify an existing Product Variant.
    /// </para>
    /// <para>
    /// DELETE /admin/api/2021-07/products/{product_id}/variants/{variant_id}.json
    /// Remove an existing Product Variant.
    /// </para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product-variant#properties-2021-07"/>.</para>
    /// </summary>
    public class ProductVariant : BaseModel
    {
        /// <summary>
        /// The unique numeric identifier for the product.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// The title of the product variant.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// A unique identifier for the product in the shop.
        /// </summary>
        [JsonPropertyName("sku")]
        public string? SKU { get; set; }

        /// <summary>
        /// The order of the product variant in the list of product variants. 1 is the first position.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The weight of the product variant in grams.
        /// </summary>
        [JsonPropertyName("grams")]
        public long? Grams { get; set; }

        /// <summary>
        /// Specifies whether or not customers are allowed to place an order for a product variant when it's out of stock. Known values are 'deny' and 'continue'.
        /// </summary>
        [JsonPropertyName("inventory_policy")]
        public string? InventoryPolicy { get; set; }

        /// <summary>
        /// Service that is doing the fulfillment. Can be 'manual' or any custom string.
        /// </summary>
        [JsonPropertyName("fulfillment_service")]
        public string? FulfillmentService { get; set; }

        /// <summary>
        /// The unique identifier for the inventory item, which is used in the Inventory API to query for inventory information.
        /// </summary>
        [JsonPropertyName("inventory_item_id")]
        public long? InventoryItemId { get; set; }

        /// <summary>
        /// Specifies whether or not Shopify tracks the number of items in stock for this product variant. Known values are 'blank' and 'shopify'.
        /// </summary>
        [JsonPropertyName("inventory_management")]
        public string? InventoryManagement { get; set; }

        /// <summary>
        /// The price of the product variant.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// The competitors prices for the same item.
        /// </summary>
        [JsonPropertyName("compare_at_price")]
        public decimal? CompareAtPrice { get; set; }

        /// <summary>
        /// Custom properties that a shop owner can use to define product variants.
        /// </summary>
        [JsonPropertyName("option1")]
        public string? Option1 { get; set; }

        /// <summary>
        /// Custom properties that a shop owner can use to define product variants.
        /// </summary>
        [JsonPropertyName("option2")]
        public string? Option2 { get; set; }

        /// <summary>
        /// Custom properties that a shop owner can use to define product variants.
        /// </summary>
        [JsonPropertyName("option3")]
        public string? Option3 { get; set; }

        /// <summary>
        /// The date and time when the product variant was created. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the product variant was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Specifies whether or not a tax is charged when the product variant is sold.
        /// </summary>
        [JsonPropertyName("taxable")]
        public bool? Taxable { get; set; }

        /// <summary>
        /// Specifies a tax code which is used for Avalara tax integrations.
        /// </summary>
        [JsonPropertyName("tax_code")]
        public string? TaxCode { get; set; }

        /// <summary>
        /// Specifies whether or not a customer needs to provide a shipping address when placing an order for this product variant.
        /// </summary>
        [JsonPropertyName("requires_shipping")]
        public bool? RequiresShipping { get; set; }

        /// <summary>
        /// The barcode, UPC or ISBN number for the product.
        /// </summary>
        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        /// <summary>
        /// The number of items in stock for this product variant.
        /// NOTE: After 2018-07-01, this field will be read-only in the Shopify API. Use the `InventoryLevelService` instead.
        /// </summary>
        [JsonPropertyName("inventory_quantity")]
        public long? InventoryQuantity { get; set; }

        /// <summary>
        /// The unique numeric identifier for one of the product's images.
        /// </summary>
        [JsonPropertyName("image_id")]
        public long? ImageId { get; set; }

        /// <summary>
        /// The weight of the product variant in the unit system specified with weight_unit.
        /// </summary>
        [JsonPropertyName("weight")]
        public decimal? Weight { get; set; }

        /// <summary>
        /// The unit system that the product variant's weight is measure in. The weight_unit can be either "g", "kg, "oz", or "lb".
        /// </summary>
        [JsonPropertyName("weight_unit")]
        public string? WeightUnit { get; set; }

        /// <summary>
        /// <para>Additional metadata about the <see cref="ProductVariant"/>.</para>
        /// <para>
        /// Note: This is not naturally returned with a <see cref="ProductVariant"/> response, as
        /// Shopify will not return <see cref="ProductVariant"/> metafields unless specified.
        /// </para>
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<MetaField>? Metafields { get; set; }

        /// <summary>
        /// A list of the variant's presentment prices and compare-at prices in each of the shop's enabled presentment currencies.
        /// </summary>
        [JsonPropertyName("presentment_prices")]
        public IEnumerable<PresentmentPrice>? PresentmentPrices { get; set; }
    }
}
