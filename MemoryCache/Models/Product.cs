﻿using System.ComponentModel.DataAnnotations;

namespace MemoryCache.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
