namespace API_EF_Hash_Token.API.Dto
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public List<AdressDTO> Adresses { get; set; } = new List<AdressDTO>();

        public UserDTO(int userId, string firstName, string lastName, string Email, int phoneNumber, string role, bool isActive, List<AdressDTO>? adresses = null)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = Email;
            this.PhoneNumber = phoneNumber;
            this.Role = role;
            this.IsActive = isActive;
            this.Adresses = adresses ?? new List<AdressDTO>();

        }
    }
}
