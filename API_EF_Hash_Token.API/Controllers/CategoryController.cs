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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            IEnumerable<CategoryDTO> categories = await _categoryService.GetAll().ContinueWith(r => r.Result.Select(c => c.ToCategoryDTO()));
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO?>> GetById(int id)
        {
            CategoryDTO? category = await _categoryService.GetById(id).ContinueWith(r => r.Result?.ToCategoryDTO());
            return category is not null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Insert(CreateCategoryForm form)
        {
          CategoryDTO? insertedCategory = await _categoryService.Insert(form.ToCategoryModel()).ContinueWith(r => r.Result?.ToCategoryDTO());
          return insertedCategory is not null ? Ok(insertedCategory) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO?>> Update(UpdateCategoryForm form, int id)
        {
            CategoryDTO? updatedCategory = await _categoryService.Update(form.ToCategoryModel(), id).ContinueWith(r => r.Result?.ToCategoryDTO());
            return updatedCategory is not null ? Ok(updatedCategory) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO?>> Delete(int id)
        {
            CategoryDTO? deletedCategory = await _categoryService.Delete(id).ContinueWith(r => r.Result?.ToCategoryDTO());
            return deletedCategory is not null ? Ok(deletedCategory) : BadRequest();
        }
    }
}
