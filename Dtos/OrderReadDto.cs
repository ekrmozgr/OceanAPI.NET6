namespace OceanAPI.NET6.Dtos
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public List<OrderProductReadDto> OrderProducts { get; set; }
        public int UserId { get; set; }
        public UserInProductReadDto User { get; set; }
        public string RecipientMail { get; set; }
    }
}
