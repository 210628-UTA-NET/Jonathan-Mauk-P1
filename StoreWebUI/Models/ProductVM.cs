using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreWebUI.Models
{
    public class ProductVM
    {
        public ProductVM()
        {

        }

        public ProductVM(Products p_product)
        {
            Id = p_product.Id;
            Name = p_product.Name;
            Price = p_product.Price;
            Description = p_product.Description;
            Category = p_product.Category;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
