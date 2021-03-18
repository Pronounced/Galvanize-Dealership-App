using System;

namespace dealership_app.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime updatedate { get; set; }
    }
}