using Microsoft.AspNetCore.Mvc;

namespace ShopifyWeb.Controllers;

public class HomeController : Controller
{
    [HttpGet("/")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public ActionResult Index()
    {
        return View();
    }
}
