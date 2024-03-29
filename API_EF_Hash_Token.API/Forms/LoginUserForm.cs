﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API_EF_Hash_Token.API.Forms
{
    public class LoginUserForm
    {
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        [MinLength(1)]
        [DefaultValue("exemple@gmail.com")]
        public string Email { get; set; }

        [Required]
        [MinLength(7)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{7,}$")]
        [DefaultValue("password")]
        public string Password { get; set; }
    }
}
