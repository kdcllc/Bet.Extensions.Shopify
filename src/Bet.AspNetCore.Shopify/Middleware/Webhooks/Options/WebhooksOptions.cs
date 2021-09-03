using System.Collections.Generic;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks.Options
{
    internal class WebhooksOptions
    {
        public IList<WebhookRegistration> WebHooksRegistrations { get; } = new List<WebhookRegistration>();

        public string HttpRoute { get; set; } = "/webhooks";

        public string HttpMethod { get; set; } = "POST";

        public bool ThrowIfException { get; set; } = true;
    }
}
