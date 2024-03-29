﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public class Basket
    {
        public Basket()
        {
            Price = 0;
            ProductCount = 0;
        }
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
    }
}
