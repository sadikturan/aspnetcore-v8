using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Web.Controllers;
public class HomeController :Controller
{
    public IActionResult Index() => View();
}