using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Bet.AspNetCore.Shopify.OAuth;

/// <summary>
/// Substitue for <see cref="AuthenticationProperties"/> to enforce setting shop name
/// before Challenge and provide an override for <see cref="OAuthOptions.Scope"/>. You
/// can accomplish the same thing by setting the approriate values in <see cref="AuthenticationProperties.Items"/>.
/// </summary>
public class OAuthAuthenticationProperties : AuthenticationProperties
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OAuthAuthenticationProperties" /> class.
    /// </summary>
    /// <param name="shopName">The name of the shop. Unlike most OAuth providers, the Shop name needs to be known in order
    /// to authorize. This must either be gotten from the user or sent from Shopify during App store
    /// installation.
    /// </param>
    public OAuthAuthenticationProperties(string shopName)
        : this(shopName, new Dictionary<string, string?>())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuthAuthenticationProperties" /> class.
    /// </summary>
    /// <param name="shopName">The name of the shop. Unlike most OAuth providers, the Shop name needs to be known in order
    /// to authorize. This must either be gotten from the user or sent from Shopify during App store
    /// installation.
    /// </param>
    /// <param name="items">Set Items values.</param>
    public OAuthAuthenticationProperties(string shopName, IDictionary<string, string?> items)
        : base(items)
    {
        SetShopName(shopName);
    }

    /// <summary>
    /// The scope requested. Must be fully formatted. <see cref="OAuthOptions.Scope"/>.
    /// </summary>
    public string? Scope
    {
        get => GetProperty(OAuthConstants.ScopeProperty);
        set => SetProperty(OAuthConstants.ScopeProperty, value);
    }

    /// <summary>
    /// Request a per user token. No offline access, do not persist.
    /// </summary>
    public bool RequestPerUserToken
    {
        get
        {
            var prop = GetProperty(OAuthConstants.GrantOptionsProperty);
            return string.Equals(prop, OAuthConstants.PerUserProperty, StringComparison.OrdinalIgnoreCase);
        }

        set => SetProperty(
            OAuthConstants.GrantOptionsProperty,
            value ? OAuthConstants.PerUserProperty : null);
    }

    /// <summary>
    /// The name of the shop. Unlike most OAuth providers, the Shop name needs to be known in order
    /// to authorize. This must either be gotten from the user or sent from Shopify during App store
    /// installation.
    /// </summary>
    private void SetShopName(string shopName)
    {
        SetProperty(OAuthConstants.ShopNameProperty, shopName);
    }

    private void SetProperty(object shopNameAuthenticationProperty, string shopName)
    {
        throw new NotImplementedException();
    }

    private void SetProperty(string propName, string? value)
    {
        Items[propName] = value;
    }

    private string? GetProperty(string propName)
    {
        return Items.TryGetValue(propName, out var val) ? val : null;
    }
}
