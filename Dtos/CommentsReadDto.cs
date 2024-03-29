﻿namespace OceanAPI.NET6.Dtos
{
    public class CommentsReadDto
    {
        public int Id { get; set; }
        public string DateOfComment { get; set; }
        public string Comment { get; set; }
        public ProductUpdateDto Product { get; set; }
        public UserInProductReadDto User { get; set; }
    }
}
