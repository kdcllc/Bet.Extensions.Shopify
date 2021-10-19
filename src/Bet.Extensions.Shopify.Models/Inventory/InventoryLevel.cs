using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Inventory;

/// <summary>
/// <seealso cref="!:https://shopify.dev/api/admin-rest/2021-10/resources/inventorylevel#resource_object"/>.
/// </summary>
public class InventoryLevel : BaseModel
{
    [JsonPropertyName("available")]
    public int Available { get; set; }

    [JsonPropertyName("inventory_item_id")]
    public long? InventoryItemId { get; set; }

    [JsonPropertyName("location_id")]
    public long? LocationId { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
}
