using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Web.Models;

public class OrderController:Controller
{
    private Cart cart;
    private IOrderRepository _orderRepository;
    public OrderController(Cart cartService, IOrderRepository orderRepository)
    {
        cart = cartService;
        _orderRepository = orderRepository;
    }

    public IActionResult Checkout()
    {
        return View(new OrderModel() { Cart = cart });
    }

    [HttpPost]
    public IActionResult Checkout(OrderModel model)
    {
        if(cart.Items.Count == 0)
        {
            ModelState.AddModelError("", "Sepetinizde ürün yok.");
        }

        if(ModelState.IsValid)
        {
            var order = new Order
            {
                Name = model.Name,
                Email = model.Email,
                City = model.City,
                Phone = model.Phone,
                AddressLine = model.AddressLine,
                OrderDate = DateTime.Now,
                OrderItems = cart.Items.Select(i => new OrderItem {
                    ProductId = i.Product.Id,
                    Price = (double)i.Product.Price,
                    Quantity = i.Quantity
                }).ToList()
            };
            _orderRepository.SaveOrder(order);
            cart.Clear();
            return RedirectToPage("/Completed", new { OrderId = order.Id });
        }   
        else
        {
            model.Cart = cart;
            return View(model);
        }
    }
}