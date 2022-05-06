namespace OceanAPI.NET6.Dtos
{
    public class OrderPurchaseDto
    {
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int UserId { get; set; }
        public string RecipientMail { get; set; }
    }
}
