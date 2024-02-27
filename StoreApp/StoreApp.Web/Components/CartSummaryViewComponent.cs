using Microsoft.AspNetCore.Mvc;
using StoreApp.Web.Models;

namespace StoreApp.Web.Components;

public class CartSummaryViewComponent:ViewComponent
{
    private Cart cart;

    public CartSummaryViewComponent(Cart cartSevice)
    {
        cart = cartSevice;
    }

    public IViewComponentResult Invoke()
    {
        return View(cart);
    }
}
