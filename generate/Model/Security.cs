using System;
using System.Collections.Generic;

#nullable disable

namespace generate.Model
{
    public partial class Security
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
    }
}
