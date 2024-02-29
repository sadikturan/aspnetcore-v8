using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
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
                OrderItems = cart.Items.Select(i => new StoreApp.Data.Concrete.OrderItem {
                    ProductId = i.Product.Id,
                    Price = (double)i.Product.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            var payment = ProcessPayment();
            if(payment.Status == "success")
            {
                return RedirectToPage("/Completed", new { OrderId = order.Id });
            }

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

    private Payment ProcessPayment()
    {
        Options options = new Options();
        options.ApiKey = "sandbox-kLKnpy2mwKyH9MHmkiPQDuZx7xhcYhdy";
        options.SecretKey = "sandbox-c4oXWsJ1xCzEGrtEt24QCz3SrROWR2O0";
        options.BaseUrl = "https://sandbox-api.iyzipay.com";
                
        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = "123456789";
        request.Price = "1";
        request.PaidPrice = "1.2";
        request.Currency = Currency.TRY.ToString();
        request.Installment = 1;
        request.BasketId = "B67832";
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = "Sadık Turan";
        paymentCard.CardNumber = "5528790000000008";
        paymentCard.ExpireMonth = "12";
        paymentCard.ExpireYear = "2030";
        paymentCard.Cvc = "123";
        paymentCard.RegisterCard = 0;
        request.PaymentCard = paymentCard;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "Sadık";
        buyer.Surname = "Turan";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        request.Buyer = buyer;

        Address shippingAddress = new Address();
        shippingAddress.ContactName = "Jane Doe";
        shippingAddress.City = "Istanbul";
        shippingAddress.Country = "Turkey";
        shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        shippingAddress.ZipCode = "34742";
        request.ShippingAddress = shippingAddress;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        request.BillingAddress = billingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "BI101";
        firstBasketItem.Name = "Binocular";
        firstBasketItem.Category1 = "Collectibles";
        firstBasketItem.Category2 = "Accessories";
        firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
        firstBasketItem.Price = "0.3";
        basketItems.Add(firstBasketItem);

        BasketItem secondBasketItem = new BasketItem();
        secondBasketItem.Id = "BI102";
        secondBasketItem.Name = "Game code";
        secondBasketItem.Category1 = "Game";
        secondBasketItem.Category2 = "Online Game Items";
        secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        secondBasketItem.Price = "0.5";
        basketItems.Add(secondBasketItem);

        BasketItem thirdBasketItem = new BasketItem();
        thirdBasketItem.Id = "BI103";
        thirdBasketItem.Name = "Usb";
        thirdBasketItem.Category1 = "Electronics";
        thirdBasketItem.Category2 = "Usb / Cable";
        thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
        thirdBasketItem.Price = "0.2";
        basketItems.Add(thirdBasketItem);
        request.BasketItems = basketItems;

        Payment payment = Payment.Create(request, options);
        return payment;
    }
}