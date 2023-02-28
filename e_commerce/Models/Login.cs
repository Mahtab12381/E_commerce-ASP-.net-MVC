using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerce.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}