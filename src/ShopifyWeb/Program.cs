using Bet.Extensions.Shopify.Abstractions.Options;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddChangeTokenOptions<ShopifyOptions>(nameof(ShopifyOptions), configureAction: (o) => { });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new () { Title = "ShopifyWeb", Version = "v1" }));

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

app.MapControllers();

app.Run();
