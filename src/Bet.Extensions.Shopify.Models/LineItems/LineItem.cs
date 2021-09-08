using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.LineItems
{
    public class LineItem : BaseModel
    {
        /// <summary>
        /// <para>The id of the product variant.</para>
        /// <para>
        /// <code>
        /// "variant_id": 39072856
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("variant_id")]
        public long? VariantId { get; set; }

        /// <summary>
        /// <para>The title of the product.</para>
        /// <para>
        /// <code>
        /// "title": "IPod Nano - 8gb"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// <para>The number of products.</para>
        /// <para>
        /// <code>
        ///  "quantity": 1
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// <para>The price of the item before discounts have been applied.</para>
        /// <para>
        /// <code>
        ///  "price": "199.00"
        /// </code>
        /// </para>
        /// </summary>
        /// <remarks>Shopify returns this value as a string.</remarks>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// <para>
        /// The amount available to fulfill.</para>
        /// <para>This is the quantity - max(refunded_quantity, fulfilled_quantity) - pending_fulfilled_quantity.</para>
        /// <para>
        /// <code>
        /// "fulfillable_quantity": 1
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("fulfillable_quantity")]
        public int? FulfillableQuantity { get; set; }

        /// <summary>
        /// <para>Service provider who is doing the fulfillment.</para>
        /// <para>Valid values are either "manual" or the name of the provider. eg: "amazon", "shipwire", etc.</para>
        /// <para>
        /// <code>
        /// "fulfillment_service": "manual"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("fulfillment_service")]
        public string? FulfillmentService { get; set; }

        /// <summary>
        /// <para>The fulfillment status of this line item.</para>
        /// <para>Known values are 'fulfilled', 'null' and 'partial'.</para>
        /// <para>
        /// <code>
        /// "fulfillment_status": null
        /// </code>
        /// </para>
        /// </summary>s
        [JsonPropertyName("fulfillment_status")]
        public string? FulfillmentStatus { get; set; }

        /// <summary>
        /// <para>States whether the order used a gift card.</para>
        /// <para>
        /// <code>
        /// "gift_card": false
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("gift_card")]
        public bool? GiftCard { get; set; }

        /// <summary>
        /// <para>The weight of the item in grams.</para>
        /// <para>
        /// <code>
        ///  "grams": 200
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("grams")]
        public long? Grams { get; set; }

        /// <summary>
        /// <para>The name of the product variant.</para>
        /// <para>
        /// <code>
        /// "name": "IPod Nano - 8gb - green
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// <para>The price of the line item in shop and presentment currencies.</para>
        /// <para>
        /// <code>
        ///  "price_set": {
        ///  "shop_money": {
        ///  "amount": "7.17",
        ///  "currency_code": "USD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "7.17",
        ///  "currency_code": "USD"
        ///  }
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("price_set")]
        public MoneyBag? PriceSet { get; set; }

        /// <summary>
        /// <para>Whether the product exists.</para>
        /// <para>
        /// <code>
        /// "product_exists": true
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("product_exists")]
        public bool? ProductExists { get; set; }

        /// <summary>
        /// <para>The unique numeric identifier for the product.</para>
        /// <para>Can be null if the original product associated with the order is deleted at a later date.</para>
        /// <para>
        /// <code>
        /// "product_id": 632910392
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// <para>Any additional properties associated with the line item.</para>
        /// <para>
        /// <code>
        ///  "properties": [
        ///  {
        ///  "name": "custom engraving",
        ///  "value": "Happy Birthday Mom!"
        ///  }
        ///  ]
        ///  </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("properties")]
        public List<Property>? Properties { get; set; }

        /// <summary>
        /// <para>States whether or not requires shipping.</para>
        /// <para>
        /// <code>
        ///  "requires_shipping": true
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("requires_shipping")]
        public bool? RequiresShipping { get; set; }

        /// <summary>
        /// <para>A unique identifier of the item.</para>
        /// <para>
        /// <code>
        /// "sku": "IPOD2008GREEN"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("sku")]
        public string? Sku { get; set; }

        /// <summary>
        /// <para>States whether or not the product was taxable.</para>
        /// <para>
        /// <code>
        /// "taxable": true
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("taxable")]
        public bool? Taxable { get; set; }

        /// <summary>
        /// <para>The total discount amount applied to this line item.</para>
        /// <para>This value is not subtracted in the line item price.</para>
        /// <para>
        /// <code>
        /// "total_discount": "0.00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("total_discount")]
        public decimal? TotalDiscount { get; set; }

        /// <summary>
        /// <para>The total discount applied to the line item in shop and presentment currencies.</para>
        /// <para>
        /// <code>
        ///  "total_discount_set": {
        ///  "shop_money": {
        ///  "amount": "0.00",
        ///  "currency_code": "USD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "0.00",
        ///  "currency_code": "USD"
        ///  }
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("total_discount_set")]
        public MoneyBag? TotalDiscountSet { get; set; }

        /// <summary>
        /// <para>The name of the inventory management system. example shopify.</para>
        /// <para>
        /// <code>
        /// "variant_inventory_management": "shopify"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("variant_inventory_management")]
        public string? VariantInventoryManagement { get; set; }

        /// <summary>
        /// <para>The title of the product variant. Can be null if the product is not a variant.</para>
        /// <para>
        /// <code>
        /// "variant_title": "green"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("variant_title")]
        public string? VariantTitle { get; set; }

        /// <summary>
        /// <para>The name of the supplier of the item.</para>
        /// <para>
        /// <code>
        ///   "vendor": null
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("vendor")]
        public string? Vendor { get; set; }

        /// <summary>
        /// <para>An array of <see cref="TaxLine"/> objects, each of which details the taxes applicable to this <see cref="LineItem"/>.</para>
        /// <para>
        /// <code>
        ///     "tax_lines": []
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("tax_lines")]
        public IEnumerable<TaxLine>? TaxLines { get; set; }

        /// <summary>
        /// <para>A list of duty objects, each containing information about a duty on the line item.</para>
        /// <para>
        /// <code>
        ///   "duties": [
        ///   {
        ///   "id": "2",
        ///   "harmonized_system_code": "520300",
        ///   "country_code_of_origin": "CA",
        ///   "shop_money": {
        ///   "amount": "164.86",
        ///   "currency_code": "CAD"
        ///   },
        ///   "presentment_money": {
        ///   "amount": "105.31",
        ///   "currency_code": "EUR"
        ///   },
        ///   "tax_lines": [
        ///   {
        ///   "title": "VAT",
        ///   "price": "16.486",
        ///   "rate": 0.1,
        ///   "price_set": {
        ///   "shop_money": {
        ///   "amount": "16.486",
        ///   "currency_code": "CAD"
        ///   },
        ///   "presentment_money": {
        ///   "amount": "10.531",
        ///   "currency_code": "EUR"
        ///   }
        ///   }
        ///   }
        ///   ],
        ///   "admin_graphql_api_id": "gid://shopify/Duty/2"
        ///   }
        ///   ]
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("duties")]
        public IEnumerable<LineItemDuty>? Duties { get; set; }

        /// <summary>
        /// <para>An ordered list of amounts allocated by discount applications.</para>
        /// <para>Each discount allocation is associated to a particular discount application.</para>
        /// <para>
        /// <code>
        ///   "discount_allocations": [
        ///   {
        ///   "amount": "5.00",
        ///   "discount_application_index": 2,
        ///   "amount_set": {
        ///   "shop_money": {
        ///   "amount": "5.00",
        ///   "currency_code": "USD"
        ///   },
        ///   "presentment_money": {
        ///   "amount": "3.96",
        ///   "currency_code": "EUR"
        ///   }
        ///   }
        ///   }
        ///   ]
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("discount_allocations")]
        public IEnumerable<DiscountAllocation>? DiscountAllocations { get; set; }

        /// <summary>
        /// <para>The location of the line item's fulfillment origin.</para>
        /// <para>
        /// <code>
        ///   "origin_location": {
        ///   "id": 1390592786454,
        ///   "country_code": "CA",
        ///   "province_code": "ON",
        ///   "name": "Apple",
        ///   "address1": "700 West Georgia Street",
        ///   "address2": "1500",
        ///   "city": "Toronto",
        ///   "zip": "V7Y 1G5"
        ///   }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("origin_location")]
        public LineItemLocation? OriginLocation { get; set; }

        /// <summary>
        /// <para>The location of the line item's destination.</para>
        /// <para>
        /// <code>
        ///   "destination_location": {
        ///   "id": 1390592786454,
        ///   "country_code": "CA",
        ///   "province_code": "ON",
        ///   "name": "Apple",
        ///   "address1": "700 West Georgia Street",
        ///   "address2": "1500",
        ///   "city": "Toronto",
        ///   "zip": "V7Y 1G5"
        ///   }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("destination_location")]
        public LineItemLocation? DestinationLocation { get; set; }
    }
}
