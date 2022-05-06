﻿using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class BasketProductCreateDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int BasketId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
    }
}
