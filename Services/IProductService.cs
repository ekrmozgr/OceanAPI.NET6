using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IProductService
    {
        Product GetProduct(int id);
    }
}
