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
        private readonly string _directory;
        private Image image;
        private string filePath;

        public ImageController(IConfiguration config, IWebHostEnvironment environment, BlogContext context)
        {
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            _directory = config.GetValue<string>("StoredFilesPath");
            _context = context;
        }


        // POST api/Images
        [HttpPost]
        public async Task<ActionResult> UploadIconFilesAsync(IFormFile file)
        {
            long size = file.Length;
            if (size > 0)
            {
                
                filePath = Path.Combine(_directory, Path.GetRandomFileName());

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                //var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //var fullPath = Path.Combine(uploads, GetUniqueFileName(file.FileName));
                //file.CopyTo(new FileStream(fullPath, FileMode.Create));
                image.Name = filePath;
            }


            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return Ok(new { size });
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);

            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
    }
}
