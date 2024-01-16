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

        public UserDTO(int userId, string firstName, string lastName, string Email, int phoneNumber, string role)
        {
            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = Email;
            this.PhoneNumber = phoneNumber;
            Role = role;

        }
    }
}
