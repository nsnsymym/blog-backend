using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogBackend.Models;
using System.Net.Mime;
using BlogBackend.Utils;
using System.Threading.Tasks;
using BlogBackend.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogBackend.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ImageController : Controller
    {
        private readonly BlogContext _context;
        private readonly long _fileSizeLimit;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private Image image;
        private string filePath;

        public ImageController(IConfiguration config, IWebHostEnvironment hostingEnvironment, BlogContext context)
        {
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // TODO: 画像サイズのFilterによるバリデーション追加
        // https://docs.microsoft.com/ja-jp/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0
        // https://garafu.blogspot.com/2013/11/aspnet-web-api_2.html


        // POST api/Images
        [HttpPost]
        public async Task<ActionResult> UploadIconFilesAsync(IFormFile file)
        {
            List<string> PermittedFileTypes = new List<string> {
                "image/jpeg",
                "image/png",
            };

            if (file != null && file.Length > 0)
            {
                if (!PermittedFileTypes.Contains(file.ContentType))
                {
                    // TODO: ファイルタイプが違う時の失敗の処理をかく
                }

                string fileName = Path.GetFileName(file.FileName);
                fileName = $@"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                // TODO: 保存先のパスをユーザーごとにディレクトリを分ける
                string filePath = contentRootPath + "/images/" + fileName;

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                Image image = new Image();
                image.Name = filePath;

                _context.Images.Add(image);
                await _context.SaveChangesAsync();

                return Ok(new { fileName });
            }
            else
            {
                string result = "ファイルアップロードに失敗しました";
                return NotFound(new { result });
            }   
        }
    }
}
