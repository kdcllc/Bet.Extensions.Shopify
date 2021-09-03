namespace Bet.Extensions.Shopify.Models
{
    public class PagedResponse<T>
    {
        public PagedResponse(T? payload = default, string? nextPageInfo = null)
        {
            Payload = payload;
            NextPageInfo = nextPageInfo;
        }

        public T? Payload { get; set; }

        public string? NextPageInfo { get; set; }
    }
}
