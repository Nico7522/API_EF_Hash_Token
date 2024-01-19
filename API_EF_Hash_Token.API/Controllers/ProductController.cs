using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EF_Hash_Token.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            IEnumerable<ProductDTO> products = await _productService.GetAll().ContinueWith(r => r.Result.Select(p => p.ToProductDTO()));
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO?>> GetById(int id)
        {
            ProductDTO? product = await _productService.GetById(id).ContinueWith(r => r.Result?.ToProductDTO());
            return product is not null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO?>> Insert(CreateProductForm form)
        {
            ProductDTO? insertedProduct = await _productService.Insert(form.ToProductModel(), form.CategoriesId, form.SizeStock.Select(st => st.ToSizeModel()).ToList()).ContinueWith(r => r.Result?.ToProductDTO());

            return insertedProduct is not null ? Ok(insertedProduct) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>?> Update(UpdateProductForm form, int id)
        {
            ProductDTO? updatedProduct = await _productService.Update(form.ToProductModel(), id).ContinueWith(r => r.Result?.ToProductDTO());
            return updatedProduct is not null ? Ok(updatedProduct) : BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO?>> Delete(int id)
        {
            ProductDTO? deletedProduct = await _productService.Delete(id).ContinueWith(r => r.Result?.ToProductDTO());
            return deletedProduct is not null ? Ok(deletedProduct) : BadRequest();
        }

        [HttpPatch(("stock/{sizeId}/{productId}"))]
        public async Task<ActionResult> UpdateStock(UpdateStockForm form,int sizeId, int productId)
        {
            bool isUpdated = await _productService.UpdateStock(sizeId, productId, form.Stock);

            return isUpdated ? Ok() : BadRequest();
        }
    }
}
