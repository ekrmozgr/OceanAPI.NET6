namespace OceanAPI.NET6.Dtos
{
    public class ProductUpdateDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public string Explanation { get; set; }
        public string CourseHourDuration { get; set; }
        public string CourseMinuteDuration { get; set; }
    }
}
