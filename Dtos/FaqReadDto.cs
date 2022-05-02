using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Dtos
{
    public class FaqReadDto
    {
        public string FaqCategoryName { get; set; }
        public List<FAQ> faqs { get; set; }
    }
}
