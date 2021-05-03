﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class Tag
    {
        public Tag()
        {
        }

        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
    }
}
