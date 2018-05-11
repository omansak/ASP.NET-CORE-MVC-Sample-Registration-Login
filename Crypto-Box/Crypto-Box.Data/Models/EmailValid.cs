using System;
using System.Collections.Generic;

namespace CryptoBox.Data.Models
{
    public partial class EmailValid
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public string ActivationKey { get; set; }
    }
}
