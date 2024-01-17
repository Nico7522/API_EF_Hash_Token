namespace API_EF_Hash_Token.API.Dto
{
    public class UserWithAdressesDTO
    {
        public UserDTO User { get; set; }

        public List<AdressDTO> Adresses { get; set; }
    }
}
