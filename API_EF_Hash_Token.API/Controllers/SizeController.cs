using API_EF_Hash_Token.API.Dto;
using API_EF_Hash_Token.API.Forms;
using API_EF_Hash_Token.API.Mappers;
using API_EF_Hash_Token.BLL.IInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API_EF_Hash_Token.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {

        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<ActionResult<SizeDTO>> GetAll()
        {
            IEnumerable<SizeDTO> sizes = await _sizeService.GetAll().ContinueWith(r => r.Result.Select(s => s.ToSizeDTO()));
            return Ok(sizes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SizeDTO?>> GetById(int id)
        {
            SizeDTO? size = await _sizeService.GetById(id).ContinueWith(r => r.Result?.ToSizeDTO());
            return size is not null ? Ok(size) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SizeDTO?>> Insert(CreateSizeForm form)
        {
            SizeDTO? insertedSize = await _sizeService.Insert(form.ToSizeModel()).ContinueWith(r => r.Result?.ToSizeDTO());
            return insertedSize is not null ? Ok(insertedSize) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SizeDTO?>> Update(UpdateSizeForm form, int id)
        {
            SizeDTO? updatedSize = await _sizeService.Update(form.ToSizeModel(), id).ContinueWith(r => r.Result?.ToSizeDTO());
            return updatedSize is not null ? Ok(updatedSize) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SizeDTO?>> Delete(int id)
        {
            SizeDTO? deletedSize = await _sizeService.Delete(id).ContinueWith(r => r.Result?.ToSizeDTO());
            return deletedSize is not null ? Ok(deletedSize) : BadRequest();
        }



    }
}
