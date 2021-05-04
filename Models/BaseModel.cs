using System;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
