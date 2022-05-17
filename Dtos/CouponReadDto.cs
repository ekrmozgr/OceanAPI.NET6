namespace OceanAPI.NET6.Dtos
{
    public class CouponReadDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
