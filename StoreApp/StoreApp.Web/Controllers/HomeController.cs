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
    public IActionResult Index(int page = 1) 
    {
        var products = _storeRepository
            .Products
            .Skip((page - 1) * pageSize)   
            .Select(p => 
                new ProductViewModel {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                }).Take(pageSize);

        return View(new ProductListViewModel {
            Products = products,
            PageInfo = new PageInfo {
                ItemsPerPage = pageSize,
                CurrentPage = page,
                TotalItems = _storeRepository.Products.Count()
            }
        });

    }
}