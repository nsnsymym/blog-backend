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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogBackend.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdminController : Controller
    {
        private readonly BlogContext _context;

        public AdminController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }
        
        // GET api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAsync(Guid id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // POST api/Admins
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAsync([Bind("Id, UserName,Password,Icon,Twitter,Github")] Admin admin)
        {
            if (admin.Password.Length > 0)
            {
                // パスワードのハッシュ化
                admin.Password = PasswordHasher.HashPassword(admin.Password);
            }
            // TODO: アイコン画像保存処理

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsync), new { id = admin.Id }, admin);
        }

        // PUT api/Admins/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Admin>> PutAsync(Guid id, [Bind("Id, UserName,Password,Icon,Twitter,Github")] Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            if (admin.Password.Length > 0)
            {
                // パスワードのハッシュ化
                admin.Password = PasswordHasher.HashPassword(admin.Password);
            }

            // TODO: アイコン画像削除/保存処理

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/Admins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAsync(Guid id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            // TODO: アイコン画像削除処理

            return admin;

        }

        private bool AdminExists(Guid id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
    }
}
