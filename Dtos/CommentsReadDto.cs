namespace OceanAPI.NET6.Dtos
{
    public class CommentsReadDto
    {
        public int Id { get; set; }
        public DateTime DateOfComment { get; set; }
        public string Comment { get; set; }
        public UserInProductReadDto User { get; set; }
    }
}
