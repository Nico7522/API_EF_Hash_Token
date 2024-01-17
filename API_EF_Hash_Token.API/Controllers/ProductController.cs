using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
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

        //[HttpPost]
        //public async Task<ProductDTO?> Insert(CreateProductForm form)
        //{
        //    //await _productService.I
        //}

        //[HttpPut("{id}")]
        //public async Task<ProductDTO?> Update(UpdateProductForm form, int id)
        //{

        //}
    }
}
