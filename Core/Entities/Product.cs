﻿
using Core.Constants.Enums;

namespace Core.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public ProductType Type { get; set; }
    }
}
