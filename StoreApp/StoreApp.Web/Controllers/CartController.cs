using Microsoft.AspNetCore.Mvc;
using StoreApp.Web.Models;

public class OrderController:Controller
{
    private Cart cart;
    public OrderController(Cart cartService)
    {
        cart = cartService;
    }

    public IActionResult Checkout()
    {
        return View(new OrderModel() { Cart = cart });
    }
}