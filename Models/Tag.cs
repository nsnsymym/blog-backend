using System;
namespace blog_backend.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public Tag()
        {
        }
    }
}
