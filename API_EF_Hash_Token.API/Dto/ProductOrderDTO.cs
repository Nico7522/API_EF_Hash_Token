﻿namespace API_EF_Hash_Token.API.Dto
{
    public class ProductOrderDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int SizeId { get; set; }
        public decimal ReductionPerProduct { get; set; }
    }
}
