using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class Admin : BaseModel
    {
        public Admin()
        {
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "ユーザー名は50文字までです。")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "パスワードは6文字以上必要です。")]
        public string Password { get; set; }
        public string Icon { get; set; }
        public string Twitter { get; set; }
        public string Github { get; set; }
    }
}
