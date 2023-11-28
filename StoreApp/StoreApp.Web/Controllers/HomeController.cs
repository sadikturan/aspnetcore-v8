using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;
public class HomeController :Controller
{
    public int pageSize = 3;
    private IStoreRepository _storeRepository;
    public HomeController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    // localhost:5000/?page=2
    public IActionResult Index(int page = 1) 
    {
        var products = _storeRepository
            .Products
            .Skip((page - 1) * pageSize)   // 1 -1 => 0 * 3 => 0   // 2 - 1 => 1 * 3 => 3  // 3 - 1 => 2 * 3 => 6
            .Select(p => 
                new ProductViewModel {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                }).Take(pageSize);

        return View(new ProductListViewModel {
            Products = products
        });

    }
}