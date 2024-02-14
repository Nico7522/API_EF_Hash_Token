using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Models
{
    public class UserModel
    {
        public int UserId { get; init; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public List<AdressModel> Adresses { get; set; } = new List<AdressModel>();
        private string _password;
        public string Password
        {   internal get { return _password; }
            set { _password = value; }
        }
        public UserModel(string lastName, string firstName, int phoneNumber)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.PhoneNumber = phoneNumber;
        }
        public UserModel(string lastName, string firstName, int phoneNumber, string email) : this(lastName, firstName, phoneNumber)
        {
            this.Email = email;
        }
        public UserModel(int id, string lastName, string firstName, string email, int phoneNumber, string role, List<AdressModel>? adresses = null) : this(lastName, firstName, phoneNumber, email)
        {
            this.UserId = id;
            this.Role = role;
            this.Adresses = adresses ?? new List<AdressModel>();
        }

        public UserModel(string lastName, string firstName, string email, int phoneNumber, string password) : this(lastName, firstName, phoneNumber, email)
        {
            
            this.Password = password;
        }
    }
}
