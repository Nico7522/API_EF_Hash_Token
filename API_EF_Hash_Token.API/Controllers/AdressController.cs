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
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdressDTO>>> GetAll()
        {
           IEnumerable<AdressDTO> adresses = await _adressService.GetAll().ContinueWith(r => r.Result.Select(a => a.ToAdressDTO()));
            return Ok(adresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdressDTO?>> GetById(int id)
        {
            AdressDTO? adress = await _adressService.GetById(id).ContinueWith(r => r.Result?.ToAdressDTO());
            return adress is not null ? Ok(adress) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AdressDTO?>> Insert(CreateAdressForm form)
        {
           AdressDTO? insertedAdress = await _adressService.Insert(form.ToAdressModel()).ContinueWith(r => r.Result?.ToAdressDTO());
           return insertedAdress is not null ? Ok(insertedAdress) : BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdressDTO?>> Update(UpdateAdressForm form ,int id)
        {
            AdressDTO? updatedAdress = await _adressService.Update(form.ToAdressModel(), id).ContinueWith(r => r.Result?.ToAdressDTO());
            return updatedAdress is not null ? Ok(updatedAdress) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AdressDTO?>> Delete(int id)
        {
            AdressDTO? deletedAdress = await _adressService.Delete(id).ContinueWith(r => r.Result?.ToAdressDTO());
            return deletedAdress is not null ? Ok(deletedAdress) : BadRequest();
        }
    }
}
