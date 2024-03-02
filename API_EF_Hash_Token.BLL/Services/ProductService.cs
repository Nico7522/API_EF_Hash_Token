﻿using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.BLL.Response;
using API_EF_Hash_Token.BLL.Utils;
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ISizeRepository sizeRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductModel?> Delete(int id)
        {

            ProductEntity? productToDelete = await _productRepository.GetById(id);
            if (productToDelete is null) return null;

            ProductModel? deletedProduct = await _productRepository.Delete(productToDelete).ContinueWith(r => r.Result?.ToProductModel());
            return deletedProduct;
        }

        public IEnumerable<ProductModel> Filter(FilterModel filter)
        {
            return _productRepository.Filter(filter.ToFilterEntity()).Select(p => p.ToProductModel());
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            return await _productRepository.GetAll().ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
            
        }

        public async Task<IEnumerable<ProductModel>> GetByBrand(string brand)
        {
            return await _productRepository.GetByBrand(brand).ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
        }

        public async Task<IEnumerable<ProductModel>?> GetByCategory(string category)
        {
            return await _productRepository.GetByCategory(category).ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
        }

        public async Task<ProductModel> GetById(int id)
        {
            ProductModel? product = await _productRepository.GetById(id).ContinueWith(r => r.Result?.ToProductModel());
            if (product is null) return null;  

            return product;
        }

        public async Task<IEnumerable<ProductModel>?> GetByPrice(decimal minPrice, decimal maxPrice)
        {
            if ((minPrice < 0 || maxPrice < 0 ) || (maxPrice < minPrice)) return null;
            return await _productRepository.GetByPrice(minPrice, maxPrice).ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
        }

        public async Task<IEnumerable<ProductModel>> GetByStep(int offset)
        {
            return await _productRepository.GetByStep(offset).ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
        }

        public async Task<IEnumerable<ProductModel>> GetByTopSales()
        {
            IEnumerable<ProductModel> products = await _productRepository.GetByTopSales().ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
            return products;
        }

        public async Task<ProductModel?> Insert(ProductModel model, List<int> categoriesId, List<SizeModel> sizeStock)
        {
        
            ProductModel? insertedProduct = await _productRepository.Insert(model.ToProductEntity(categoriesId, sizeStock)).ContinueWith(r => r.Result?.ToProductModel());
            return insertedProduct;
        }

        public async Task<bool> SaveChange()
        {
            bool isSaved = await _productRepository.SaveChange();
            return isSaved;
        }

        public async Task<ProductModel?> Update(ProductModel modifiedProduct, int id)
        {

            ProductEntity? productToUpdate = await _productRepository.GetById(id);
            if (productToUpdate is null) return null;

            ProductModel? updatedProduct = await _productRepository.Update(productToUpdate, modifiedProduct.ToProductEntity()).ContinueWith(r => r.Result?.ToProductModel());
            return updatedProduct;
        }

        public async Task<bool> UpdatePicture(int productId, string imageUrl)
        {
            if (!Method.VerifyExtension(imageUrl)) return false;

            ProductEntity? productFound = await _productRepository.GetById(productId);
            if(productFound is null) return false;

            bool isUpdated = await _productRepository.UpdatePicture(productFound, imageUrl);
            return isUpdated;
        }

        public async Task<bool> UpdateStock(int sizeId, int productId, int stock)
        {
            // Check si le produit existe
            ProductEntity? productFound = await _productRepository.GetById(productId);
            if (productFound is null) return false;

            // check si la taille existe
            SizeEntity? sizeFound = await _sizeRepository.GetById(sizeId);
            if (sizeFound is null) return false;

            bool isUpdated = await _productRepository.UpdateStock(sizeId, productId, stock);
            return isUpdated;
        }

        public async Task<bool> RemoveCategoryFromProduct(int productId, int CategoryId)
        {
            ProductEntity? product = await _productRepository.GetById(productId);
            if (product is null) return false;
            CategoryEntity? categoryToRemove = await _categoryRepository.GetById(CategoryId);
            if (categoryToRemove is null) return false;

            return await _productRepository.RemoveCategoryFromProduct(product, categoryToRemove);

        }

        public async Task<bool> AddSize(int productId, int sizeId, int stock)
        {
            ProductEntity? product = await _productRepository.GetById(productId);
            SizeEntity? sizeToAdd = await _sizeRepository.GetById(sizeId);

           return await _productRepository.AddSize(product, sizeToAdd, stock);
        }

        public async Task<bool> RemoveSizeFormProduct(int productId, int sizeId)
        {
            ProductEntity? product = await _productRepository.GetById(productId);
            if (product is null) return false;
            SizeEntity? sizeToRemove = await _sizeRepository.GetById(sizeId);
            if (sizeToRemove is null) return false;
            await Console.Out.WriteLineAsync("cc");
            return await _productRepository.RemoveSizeFromProduct(product, sizeToRemove);
        }
    }
}
