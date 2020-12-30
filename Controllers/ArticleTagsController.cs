using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_backend.Models;

namespace blog_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleTagsController : ControllerBase
    {
        private readonly ArticleTagContext _context;

        public ArticleTagsController(ArticleTagContext context)
        {
            _context = context;
        }

        // GET: api/ArticleTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleTag>>> GetArticleTag()
        {
            return await _context.ArticleTag.ToListAsync();
        }

        // GET: api/ArticleTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleTag>> GetArticleTag(long id)
        {
            var articleTag = await _context.ArticleTag.FindAsync(id);

            if (articleTag == null)
            {
                return NotFound();
            }

            return articleTag;
        }

        // PUT: api/ArticleTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleTag(long id, ArticleTag articleTag)
        {
            if (id != articleTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(articleTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleTagExists(id))
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

        // POST: api/ArticleTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticleTag>> PostArticleTag(ArticleTag articleTag)
        {
            _context.ArticleTag.Add(articleTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticleTag", new { id = articleTag.Id }, articleTag);
        }

        // DELETE: api/ArticleTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleTag(long id)
        {
            var articleTag = await _context.ArticleTag.FindAsync(id);
            if (articleTag == null)
            {
                return NotFound();
            }

            _context.ArticleTag.Remove(articleTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticleTagExists(long id)
        {
            return _context.ArticleTag.Any(e => e.Id == id);
        }
    }
}
