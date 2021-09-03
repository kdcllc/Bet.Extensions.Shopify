using System.Text;

using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Models.Products;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using ShopifyWeb.Events.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddChangeTokenOptions<ShopifyOptions>(nameof(ShopifyOptions), configureAction: (o) => { });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new () { Title = "ShopifyWeb", Version = "v1" }));

builder.Services.AddEndpointsApiExplorer();

var authBuilder = builder.Services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme);

authBuilder.AddCookie(options =>
            {
                options.LoginPath = "/signin";
                options.LogoutPath = "/signout";

                // requires to support iframe in Shopify store.
                options.Cookie.SameSite = SameSiteMode.None;
            })
           .AddShopify(configure: o =>
            {
                var opt = new ShopifyOptions();
                builder.Configuration.Bind(nameof(ShopifyOptions), opt);

                o.ClientId = opt.ApiKey!;
                o.ClientSecret = opt.ShopAccessToken!;

                // o.Scope.Add("read_all_orders");
                // o.Scope.Add("read_orders");
                // o.Scope.Add("write_orders");
                o.Scope.Add("read_customers");
                o.Scope.Add("read_products");
                o.Scope.Add("read_product_listings");
            });

builder.Services.AddShopifyHmacValidator((options, sp) =>
{
    options.WebHookPaths.Add("/OrderWebhook");
    options.WebHookPaths.Add("/api​/Webhook​/Order");
});

builder.Services.AddShopifyWebHooks()
        .AddWebhook<ProductCreateEventHandler, Product>("products/create", "products/update");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopifyWeb v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseShopifyHmacValidation();

app.UseShopifyWebhooks();

app.MapControllers();

app.UseHttpLogging();

app.MapPost(
    "/OrderWebhook",
    async (HttpRequest request) =>
    {
        using var reader = new StreamReader(request.Body, Encoding.UTF8);
        return await reader.ReadToEndAsync();
    });

app.Run();
