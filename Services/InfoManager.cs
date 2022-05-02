using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class InfoManager : IInfoService
    {
        private readonly IFaqRepository _faqRepository;
        private readonly ICompanyContactRepository _companyContactRepository;
        public InfoManager(IFaqRepository faqRepository, ICompanyContactRepository companyContactRepository)
        {
            _faqRepository = faqRepository;
            _companyContactRepository = companyContactRepository;
        }

        public async Task<CompanyContacts> GetCompanyContacts()
        {
            return await _companyContactRepository.GetCompanyContact();
        }

        public async Task<List<FAQCategory>> GetFaqs()
        {
            return await _faqRepository.GetFaqs();
        }
    }
}
