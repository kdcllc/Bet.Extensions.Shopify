using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Products
{
    /// <summary>
    /// An object representing a product image.
    /// <see href="https://shopify.dev/api/admin/rest/reference/products/product-image#properties-2021-07"/>.
    /// </summary>
    public class ProductImage : BaseModel
    {
        /// <summary>
        /// <para>The date and time when the product image was created.</para>
        /// <para>The API returns this value in ISO 8601 format.</para>
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// <para>The order of the product image in the list.</para>
        /// <para>The first product image is at position 1 and is the "main" image for the product.</para>
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The id of the product associated with the image.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// An array of variant ids associated with the image.
        /// </summary>
        [JsonPropertyName("variant_ids")]
        public IEnumerable<long>? VariantIds { get; set; }

        /// <summary>
        /// <para>Specifies the location of the product image.</para>
        /// <para>This parameter supports URL filters that you can use to retrieve modified copies of the image.</para>
        /// <para>For example, add _small, to the filename to retrieve a scaled copy of the image at 100 x 100 px (for example, ipod-nano_small.png),</para>
        /// <para>or add _2048x2048 to retrieve a copy of the image constrained at 2048 x 2048 px resolution (for example, ipod-nano_2048x2048.png).</para>
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }

        /// <summary>
        /// Width dimension of the image which is determined on upload.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Height dimension of the image which is determined on upload.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// The date and time when the product image was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Specifies the file name of the image when creating a <see cref="ProductImage"/>, where it's then converted into the <see cref="Src"/> path.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// A base64 image attachment. Only used when creating a <see cref="ProductImage"/>, where it's then converted into the <see cref="Src"/>.
        /// </summary>
        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        /// <summary>
        /// Alternative name for the image.
        /// </summary>
        [JsonPropertyName("alt")]
        public string? Alt { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="ProductImage"/>. Note: This is not naturally returned with a <see cref="ProductImage"/> response, as
        /// Shopify will not return <see cref="ProductImage"/> metafields unless specified.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<MetaField>? Metafields { get; set; }
    }
}
