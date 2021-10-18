namespace Bet.Extensions.Shopify.Models.Products;

/// <summary>
/// <para>Shopify API lets you do the following with the Collect resource. More detailed versions of these general actions may be available:</para>
/// <para>
/// POST /admin/api/2021-07/collects.json
/// Adds a product to a custom collection.
/// </para>
/// <para>
/// DELETE /admin/api/2021-07/collects/{collect_id}.json
/// Removes a product from a collection.
/// </para>
/// <para>
/// GET /admin/api/2021-07/collects.json
/// Retrieves a list of collects.
/// </para>
/// <para>
/// GET /admin/api/2021-07/collects/count.json
/// Retrieves a count of collects.
/// </para>
/// <para>
/// GET /admin/api/2021-07/collects/{collect_id}.json
/// Retrieves a specific collect by its ID.
/// </para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/products/collect#properties-2021-07"/>.</para>
/// </summary>
public class Collect
{
    /// <summary>
    /// A unique numeric identifier for the collect.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// The ID of the custom collection containing the product.
    /// </summary>
    [JsonPropertyName("collection_id")]
    public long CollectionId { get; set; }

    /// <summary>
    /// The unique numeric identifier for the product in the custom collection.
    /// </summary>
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    /// <summary>
    /// The date and time (ISO 8601 format) when the collect was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The date and time (ISO 8601 format) when the collect was last updated.
    /// <code>
    /// "updated_at": "2018-04-25T13:51:12-04:00"
    /// </code>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// The position of this product in a manually sorted custom collection.
    /// The first position is 1.
    /// This value is applied only when the custom collection is sorted manually.
    /// </summary>
    [JsonPropertyName("position")]
    public long Position { get; set; }

    /// <summary>
    /// This is the same value as position but padded with leading zeroes to make it alphanumeric-sortable.
    /// This value is applied only when the custom collection is sorted manually.
    /// <code>
    /// "sort_value": "0000000002"
    /// </code>
    /// </summary>
    [JsonPropertyName("sort_value")]
    public string? SortValue { get; set; }
}
