namespace OceanAPI.NET6.Dtos
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public UserInProductReadDto User { get; set; }
        public decimal Price { get; set; }
        public string DateOfOrder { get; set; }
        public string RecipientMail { get; set; }
        public List<OrderProductReadDto> OrderProducts { get; set; }
        public List<CouponReadDto> Coupons { get; set; }
    }
}
