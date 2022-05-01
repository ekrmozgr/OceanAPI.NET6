namespace OceanAPI.NET6.Dtos
{
    public class ProductReadDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Explanation { get; set; }
        public string CourseHourDuration { get; set; }
        public string CourseMinuteDuration { get; set; }
    }
}
