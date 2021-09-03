using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Products
{
    /// <summary>
    /// <para>The Shopify API lets you do the following with the Product resource. More detailed versions of these general actions may be available:</para>
    /// <para>
    /// GET /admin/api/2021-07/products.json
    /// Retrieve a list of products.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/products/count.json
    /// Retrieve a count of products.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/products/{product_id}.json
    /// Retrieve a single product.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/products.json
    /// Create a new product.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/products/{product_id}.json
    /// Updates a product.
    /// </para>
    /// <para>
    /// DELETE /admin/api/2021-07/products/{product_id}.json
    /// Delete a product.
    /// </para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product#properties-2021-07"/>.</para>
    /// </summary>
    public class Product : BaseModel
    {
        /// <summary>
        /// The name of the product. In a shop's catalog, clicking on a product's title takes you to that product's page.
        /// On a product's page, the product's title typically appears in a large font.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The description of the product, complete with HTML formatting.
        /// </summary>
        [JsonPropertyName("body_html")]
        public string? BodyHtml { get; set; }

        /// <summary>
        /// The date and time when the product was created. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the product was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// The date and time when the product was published. The API returns this value in ISO 8601 format.
        /// Set to NULL to unpublish a product.
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        /// <summary>
        /// The name of the vendor of the product.
        /// </summary>
        [JsonPropertyName("vendor")]
        public string? Vendor { get; set; }

        /// <summary>
        /// A categorization that a product can be tagged with, commonly used for filtering and searching.
        /// </summary>
        [JsonPropertyName("product_type")]
        public string? ProductType { get; set; }

        /// <summary>
        /// A human-friendly unique string for the Product automatically generated from its title.
        /// They are used by the Liquid templating language to refer to objects.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// The suffix of the liquid template being used.
        /// By default, the original template is called product.liquid, without any suffix.
        /// Any additional templates will be: product.suffix.liquid.
        /// </summary>
        [JsonPropertyName("template_suffix")]
        public string? TemplateSuffix { get; set; }

        /// <summary>
        /// The sales channels in which the product is visible.
        /// web or global.
        /// </summary>
        [JsonPropertyName("published_scope")]
        public string? PublishedScope { get; set; }

        /// <summary>
        /// A categorization that a product can be tagged with, commonly used for filtering and searching.
        /// Each comma-separated tag has a character limit of 255.
        /// </summary>
        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        /// <summary>
        /// The status of the product.
        /// active, archived, draft.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// SEO Title is for update only field.
        /// The Admin Api doesn't return this value.
        /// </summary>
        [JsonPropertyName("metafields_global_title_tag")]
        public string? SeoTitle { get; set; }

        /// <summary>
        /// SEO Description is for update only field.
        /// The Admin Api Deosn't return this fields.
        /// </summary>
        [JsonPropertyName("metafields_global_description_tag")]
        public string? SeoDescription { get; set; }

        /// <summary>
        /// A list of variant objects, each one representing a slightly different version of the product.
        /// For example, if a product comes in different sizes and colors, each size and color permutation (such as "small black", "medium black", "large blue"), would be a variant.
        /// To reorder variants, update the product with the variants in the desired order.The position attribute on the variant will be ignored.
        /// </summary>
        [JsonPropertyName("variants")]
        public IEnumerable<ProductVariant>? Variants { get; set; }

        /// <summary>
        /// Custom product property names like "Size", "Color", and "Material".
        /// Products are based on permutations of these options.
        /// A product may have a maximum of 3 options. 255 characters limit each.
        /// </summary>
        [JsonPropertyName("options")]
        public IEnumerable<ProductOption>? Options { get; set; }

        /// <summary>
        /// A list of image objects, each one representing an image associated with the product.
        /// </summary>
        [JsonPropertyName("images")]
        public IEnumerable<ProductImage>? Images { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="Product"/>. Note: This is not naturally returned with a <see cref="Product"/> response, as
        /// Shopify will not return <see cref="Product"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetaFieldService"/>.
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<MetaField>? Metafields { get; set; }

        /// <summary>
        /// Get the item to be published.
        /// </summary>
        [JsonPropertyName("published")]
        public bool? Published { get; set; }
    }
}
