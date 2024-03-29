﻿using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class CommentsUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Comment { get; set; }
    }
}
