using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Web.Components;

public class CategoriesListViewComponent:ViewComponent
{
    private readonly IStoreRepository _storeRepository;
    public CategoriesListViewComponent(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public IViewComponentResult Invoke()
    {
        return View(_storeRepository
                    .Products
                    .Select(c => c.Category)
                    .Distinct()
                    .OrderBy(c => c));
    }
}