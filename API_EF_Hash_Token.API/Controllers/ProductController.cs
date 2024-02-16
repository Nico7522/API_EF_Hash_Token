using API_EF_Hash_Token.API.ApiResponse;
using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>>> GetAll()
        {
            IEnumerable<ProductDTO>? products = await _productService.GetAll().ContinueWith(r => r.Result.Select(p => p.ToProductDTO()));
            return Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products));
        }
        [HttpGet("paginate")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>>> GetByStep([FromQuery] int offset = 0)
        {
            IEnumerable<ProductDTO> products = await _productService.GetByStep(offset).ContinueWith(r => r.Result.Select(p => p.ToProductDTO()));
            return Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products));

        }

        [HttpGet("search/category")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>?>> GetByCategory([FromQuery] string category)
        {
            IEnumerable<ProductDTO>? products = await _productService.GetByCategory(category).ContinueWith(r => r.Result?.Select(p => p.ToProductDTO()));
            return products is not null ? Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products)) : NotFound(ApiResponse<ProductDTO>.Failed(message: "Error", status: 400));
        }

        [HttpGet("search/brand")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>?>> GetByBrand([FromQuery] string brand)
        {
            IEnumerable<ProductDTO>? products = await _productService.GetByBrand(brand).ContinueWith(r => r.Result?.Select(p => p.ToProductDTO()));
            return products is not null ? Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products)) : NotFound(ApiResponse<ProductDTO>.Failed(message: "Error", status: 404));
        }

        [HttpGet("search/price")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>?>> GetByPrice([FromQuery] decimal minPrice, decimal maxPrice)
        {
            IEnumerable<ProductDTO>? products = await _productService.GetByPrice(minPrice, maxPrice).ContinueWith(r => r.Result?.Select(p => p.ToProductDTO()));
            return products is not null ? Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products)) : NotFound(ApiResponse<ProductDTO>.Failed(message: "Error", status: 404));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> GetById(int id)
        {
            ProductDTO? product = await _productService.GetById(id).ContinueWith(r => r.Result?.ToProductDTO());

            return product is not null ? Ok(ApiResponse<ProductDTO>.Success(product)) : NotFound(ApiResponse<ProductDTO>.Failed(message: "Id not found", status: 404));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> Insert(CreateProductForm form)
        {
            ProductDTO? insertedProduct = await _productService.Insert(form.ToProductModel(), form.CategoriesId, form.SizeStock.Select(st => st.ToSizeModel()).ToList()).ContinueWith(r => r.Result?.ToProductDTO());

            return insertedProduct is not null ? Ok(ApiResponse<ProductDTO>.Success(insertedProduct)) : BadRequest(ApiResponse<ProductDTO>.Failed(message: "Product not inserted", status: 404));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> Update(UpdateProductForm form, int id)
        {
            ProductDTO? updatedProduct = await _productService.Update(form.ToProductModel(), id).ContinueWith(r => r.Result?.ToProductDTO());
            return updatedProduct is not null ? Ok(ApiResponse<ProductDTO>.Success(updatedProduct)) : BadRequest(ApiResponse<ProductDTO>.Failed(message: "Product not updated", status: 404));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> Delete(int id)
        {
            ProductDTO? deletedProduct = await _productService.Delete(id).ContinueWith(r => r.Result?.ToProductDTO());
            return deletedProduct is not null ? Ok(ApiResponse<ProductDTO>.Success(deletedProduct)) : BadRequest(ApiResponse<ProductDTO>.Failed(message: "Product not deleted", status: 404));
        }

        [HttpPatch(("stock/{sizeId}/{productId}"))]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> UpdateStock(UpdateStockForm form,int sizeId, int productId)
        {
            bool isUpdated = await _productService.UpdateStock(sizeId, productId, form.Stock);

            return isUpdated ? Ok(ApiResponse<ProductDTO>.Success(message: "updated")) : BadRequest(ApiResponse<ProductDTO>.Failed(message: "Product not deleted", status: 404));
        }

        [HttpGet("top")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>>> GetByTopSales()
        {
            IEnumerable<ProductDTO> products = await _productService.GetByTopSales().ContinueWith(r => r.Result.Select(p => p.ToProductDTO()));
            return Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products));
        }

        [HttpPut("{id}/image")]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> UpdatePicture(int id, [FromForm] FileForm image)
        {
            if (image is null) return BadRequest(ApiResponse<ProductDTO>.Failed());

            try
            {
                bool isUpdated = await _productService.UpdatePicture(id, image.File.FileName);
                string path = Path.Combine(image.Directory, image.File.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    image.File.CopyTo(stream);
                }

                if (!isUpdated) return BadRequest(ApiResponse<ProductDTO>.Failed());

                bool isSaved = await _productService.SaveChange();

                return (isUpdated && isSaved) ? NoContent() : throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ProductDTO>.Failed());
            }
        }
    }
}
