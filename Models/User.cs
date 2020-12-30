using System;
namespace blog_backend.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public User()
        {
        }
    }
}
