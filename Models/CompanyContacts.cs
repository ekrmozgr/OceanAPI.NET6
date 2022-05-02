using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Models
{
    public class CompanyContacts
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
