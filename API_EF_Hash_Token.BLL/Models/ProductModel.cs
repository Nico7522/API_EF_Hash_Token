﻿using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class ProductModel
    {
        public int ProductId { get; init; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Sexe { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public List<CategoryModel>? Categories { get; set; }

        public ProductModel(string modelName, string description, string brand, string sexe, decimal price, decimal discount)
        {
            this.ModelName = modelName;
            this.Description = description;
            this.Brand = brand;
            this.Sexe = sexe;
            this.Price = price;
            this.Discount = discount;

        }
        public ProductModel(string modelName, string description, string brand, string sexe, decimal price, decimal discount, int productId) : this(modelName, description, brand, sexe, price, discount)
        {
            this.ProductId = productId;
        }
        public ProductModel(string modelName, string description, string brand, string sexe, decimal price, decimal discount, List<CategoryModel> categories): this (modelName, description, brand, sexe, price, discount)
        {
            Categories = categories ?? new List<CategoryModel>();
        }

        public ProductModel(string modelName, string description, string brand, string sexe, decimal price, decimal discount, int productId, List<CategoryModel> categories) : this(modelName, description, brand, sexe, price,  discount, categories)
        {
            this.ProductId = productId;
        }
    }
}