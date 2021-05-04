using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class Admin : BaseModel
    {
        [Display(Name = "ユーザー名")]
        [Required]
        [StringLength(50, ErrorMessage = "{0}は{1}文字までです。")]
        public string UserName { get; set; }

        [Display(Name = "パスワード")]
        [Required]
        [MinLength(6, ErrorMessage = "{0}は{1}文字以上必要です。")]
        public string Password { get; set; }

        [Display(Name = "アイコン画像")]
        public string Icon { get; set; }

        [Display(Name = "TwitterID")]
        public string Twitter { get; set; }

        [Display(Name = "GithubID")]
        public string Github { get; set; }
    }
}
