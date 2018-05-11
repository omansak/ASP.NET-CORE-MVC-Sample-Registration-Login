using System;
using System.Collections.Generic;

namespace CryptoBox.Data.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailValid { get; set; }
    }
}
