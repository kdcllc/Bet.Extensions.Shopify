using System.Reflection;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify;

public static class ShopifyExtensions
{
    public static string CompileRequestUri(
        this IList<KeyValuePair<string, object>>? parameters,
        string requestUri)
    {
        if (parameters != null)
        {
            var d = parameters.Select(item =>
            {
                var v = item.Value.ToString();
                if (item.Key != "page_info")
                {
                    v = Uri.EscapeDataString(v);
                }

                return $"{item.Key}={v}";
            });

            var ub = new UriBuilder("https://localhost")
            {
                Query = string.Join("&", d)
            };

            return $"{requestUri}{ub.Uri.Query}";
        }

        return requestUri;
    }

    public static string GetPageInfo(this HttpResponseMessage? response)
    {
        var pageInfo = string.Empty;

        if (response != null
            && response.Headers.TryGetValues("Link", out var header))
        {
            var link = header.FirstOrDefault();

            if (link != null)
            {
                foreach (var content in link.Split(","))
                {
                    if (content.Contains("next"))
                    {
                        pageInfo = content.Split(";")[0].TrimStart('<').TrimEnd('>').Split("page_info=")[1];
                    }
                }
            }
        }

        return pageInfo;
    }

    public static IList<KeyValuePair<string, object>> ToKeyValuePair(this object request)
    {
        var output = new List<KeyValuePair<string, object>>();

        foreach (var property in request.GetType().GetProperties())
        {
            var value = property.GetValue(request);
            var propName = property.Name;

            if (value == null)
            {
                continue;
            }

            if (property.CustomAttributes.Any(x => x.AttributeType == typeof(JsonPropertyNameAttribute)))
            {
                var attribute = property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false).Cast<JsonPropertyNameAttribute>().FirstOrDefault();
                propName = attribute != null ? attribute.Name : property.Name;
            }

            var parameter = ToSingleParameter(propName, value);

            output.Add(parameter);
        }

        return output;
    }

    private static KeyValuePair<string, object> ToSingleParameter(string propName, object input)
    {
        KeyValuePair<string, object> Join<T>(IEnumerable<T> values)
        {
            return new KeyValuePair<string, object>(propName, string.Join(",", values));
        }

        switch (input)
        {
            case IEnumerable<long> longs:
                return Join(longs);

            case IEnumerable<int> ints:
                return Join(ints);

            case IEnumerable<string> strings:
                return Join(strings);

            case IEnumerable<bool> bools:
                return Join(bools);
        }

        var valueType = input.GetType();

        if (valueType.GetTypeInfo().IsEnum)
        {
            input = ((Enum)input).ToSerializedString();
        }

        // Dates must be serialized in YYYY-MM-DD HH:MM format.
        if (valueType == typeof(DateTime) || valueType == typeof(DateTime?))
        {
            input = ((DateTime)input).ToString("o");
        }
        else if (valueType == typeof(DateTimeOffset) || valueType == typeof(DateTimeOffset?))
        {
            input = ((DateTimeOffset)input).ToString("o");
        }

        return new KeyValuePair<string, object>(propName, input);
    }
}
