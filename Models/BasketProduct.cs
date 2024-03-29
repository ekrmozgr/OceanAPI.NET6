﻿namespace OceanAPI.NET6.Models
{
    public class BasketProduct
    {
        public int BasketId { get; set; }
        public Basket Basket { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductQuantity { get; set; }
    }
}
