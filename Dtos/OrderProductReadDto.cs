namespace OceanAPI.NET6.Dtos
{
    public class OrderProductReadDto
    {
        public int ProductId { get; set; }
        public ProductReadDto Product { get; set; }

        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
