using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Products
{
    /// <summary>
    /// An object representing a product image.
    /// </summary>
    public class ProductImage : BaseModel
    {
        /// <summary>
        /// The id of the product associated with the image.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// The order of the product image in the list. The first product image is at position 1 and is the "main" image for the product.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The date and time when the product image was created. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the product image was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Specifies the location of the product image.
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }

        /// <summary>
        /// Specifies the file name of the image when creating a <see cref="ProductImage"/>, where it's then converted into the <see cref="Src"/> path
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// A base64 image attachment. Only used when creating a <see cref="ProductImage"/>, where it's then converted into the <see cref="Src"/>.
        /// </summary>
        [JsonPropertyName("attachment")]
        public string? Attachment { get; set; }

        /// <summary>
        /// An array of variant ids associated with the image.
        /// </summary>
        [JsonPropertyName("variant_ids")]
        public IEnumerable<long>? VariantIds { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("alt")]
        public string? Alt { get; set; }

        /// <summary>
        /// Additional metadata about the <see cref="ProductImage"/>. Note: This is not naturally returned with a <see cref="ProductImage"/> response, as
        /// Shopify will not return <see cref="ProductImage"/> metafields unless specified. Instead, you need to query metafields with <see cref="MetaFieldService"/>.
        /// Uses include: Creating, updating, and deserializing webhook bodies that include them.
        /// </summary>
        [JsonPropertyName("metafields")]
        public IEnumerable<MetaField>? Metafields { get; set; }
    }
}
