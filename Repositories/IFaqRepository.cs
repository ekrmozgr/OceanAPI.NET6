using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IFaqRepository
    {
        Task<List<FAQCategory>> GetFaqs();
    }
}
