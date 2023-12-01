using AutoMapper;
using StoreApp.Data.Concrete;

namespace StoreApp.Web.Models;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductViewModel>();
    }
}