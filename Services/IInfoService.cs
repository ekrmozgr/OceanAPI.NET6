using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IInfoService
    {
        Task<List<FAQCategory>> GetFaqs();
        Task<CompanyContacts> GetCompanyContacts();
    }
}
