using System;
using System.Collections.Generic;

#nullable disable

namespace generate.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Birtday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
