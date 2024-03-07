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

        [HttpGet("search/filter")]
        public ActionResult<ApiResponse<IEnumerable<ProductDTO>>> Filter([FromQuery] FilterForm form)
        {
            IEnumerable<ProductDTO>? products = _productService.Filter(form.ToFilterModel()).Select(p => p.ToProductDTO());
            return products is not null ? Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products)) : NotFound(ApiResponse<ProductDTO>.Failed(message: "Error", status: 400));
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
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>?>> GetByPrice([FromQuery] decimal? minPrice, decimal? maxPrice)
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
        public async Task<ActionResult<ApiResponse<ProductDTO>>> UpdateStock(UpdateStockForm form, int sizeId, int productId)
        {
            ProductDTO? updatedProduct = await _productService.UpdateStock(sizeId, productId, form.Stock).ContinueWith(r => r.Result?.ToProductDTO());

            return updatedProduct is not null ? Ok(ApiResponse<ProductDTO>.Success(data: updatedProduct, message: "updated")) : BadRequest(ApiResponse<ProductDTO>.Failed(message: "Product not deleted", status: 404));
        }

        [HttpGet("top")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDTO>>>> GetByTopSales()
        {
            IEnumerable<ProductDTO> products = await _productService.GetByTopSales().ContinueWith(r => r.Result.Select(p => p.ToProductDTO()));
            return Ok(ApiResponse<IEnumerable<ProductDTO>>.Success(products));
        }

        [HttpPut("{id}/image")]
        public async Task<ActionResult<ApiResponse<string>>> UpdatePicture(int id, [FromForm] FileForm image)
        {
            if (image is null) return BadRequest(ApiResponse<ProductDTO>.Failed());
            string now = DateTime.UtcNow.ToString("yyyyMMdd");
            string rng = Guid.NewGuid().ToString();
            string ext = Path.GetExtension(image.File.FileName);
            string filename = now + "-" + rng + ext;

            try
            {
                string? newImage = await _productService.UpdatePicture(id, filename);
                string path = Path.Combine(image.Directory, filename);
                using (Stream stream = new FileStream(path, FileMode.CreateNew))
                {
                    image.File.CopyTo(stream);
                }

                if (newImage is null) return BadRequest(ApiResponse<ProductDTO>.Failed());

                bool isSaved = await _productService.SaveChange();

                return (newImage is not null && isSaved) ? Ok(ApiResponse<string>.Success(data: newImage, message: "updated")) : throw new Exception();
            }
            catch (Exception)
            {
                return BadRequest(ApiResponse<ProductDTO>.Failed());
            }
        }

        [HttpPost("{productId:int}/category")]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> AddCategoryToProduct(int productId, AddCategoryToProductForm form )
        {
            ProductDTO? updatedProduct = await _productService.AddCategoryToProduct(productId, form.CategoryId).ContinueWith(r => r.Result?.ToProductDTO());
            return updatedProduct is not null ? Ok(ApiResponse<ProductDTO>.Success(data: updatedProduct, message: "updated")) : BadRequest();
        }

        [HttpDelete("{productId:int}/category/{categoryId:int}")]
        public async Task<ActionResult<bool>> RemoveCategoryFromProduct(int productId, int categoryId)
        {
            bool isCategoryRemoved = await _productService.RemoveCategoryFromProduct(productId, categoryId);
            return isCategoryRemoved ? Ok(isCategoryRemoved) : BadRequest();
        }

        [HttpPost("{productId:int}/size/{sizeId:int}")]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> AddSizeToProduct(int productId, int sizeId, AddSizeForm form)
        {
            ProductDTO? updatedProduct = await _productService.AddSizeToProduct(productId, sizeId, form.Stock).ContinueWith(r => r.Result?.ToProductDTO());
            return updatedProduct is not null ? Ok(ApiResponse<ProductDTO>.Success(data: updatedProduct, message: "updated")) : BadRequest();
        }

        [HttpDelete("{productId:int}/size/{sizeId:int}")]
        public async Task<ActionResult<bool>> RemoveSizeFromProduct(int productId, int sizeId)
        {
            bool isSizeRemoved = await _productService.RemoveSizeFromProduct(productId, sizeId);
            return isSizeRemoved ? Ok(isSizeRemoved) : BadRequest();
        }

    }
}
