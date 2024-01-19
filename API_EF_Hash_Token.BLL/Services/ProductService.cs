using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Mappers;
using API_EF_Hash_Token.BLL.Models;
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

        public ProductService(IProductRepository productRepository, ISizeRepository sizeRepository)
        {
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
        }

        public async Task<ProductModel?> Delete(int id)
        {

            ProductEntity? productToDelete = await _productRepository.GetById(id);
            if (productToDelete is null) return null;

            ProductModel? deletedProduct = await _productRepository.Delete(productToDelete).ContinueWith(r => r.Result?.ToProductModel());
            return deletedProduct;
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            return await _productRepository.GetAll().ContinueWith(r => r.Result.Select(p => p.ToProductModel()));
        }

        public async Task<ProductModel?> GetById(int id)
        {
            return await _productRepository.GetById(id).ContinueWith(r => r.Result?.ToProductModel());
        }

        public async Task<ProductModel?> Insert(ProductModel model, List<int> categoriesId, List<SizeModel> sizeStock)
        {
        
            ProductModel? insertedProduct = await _productRepository.Insert(model.ToProductEntity(categoriesId, sizeStock)).ContinueWith(r => r.Result?.ToProductModel());
            return insertedProduct;
        }

        public async Task<ProductModel?> Update(ProductModel modifiedProduct, int id)
        {

            ProductEntity? productToUpdate = await _productRepository.GetById(id);
            if (productToUpdate is null) return null;

            ProductModel? updatedProduct = await _productRepository.Update(productToUpdate, modifiedProduct.ToProductEntity()).ContinueWith(r => r.Result?.ToProductModel());
            return updatedProduct;
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
    }
}
