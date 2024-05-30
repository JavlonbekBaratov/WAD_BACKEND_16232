using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_16232.Data.Migrations;
using WAD_BACKEND_16232.Models;

namespace WAD_BACKEND_16232.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyCategoryController : ControllerBase
    {
        private readonly KeyStoreDbContext _context;

        public KeyCategoryController(KeyStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/KeyCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeyCategory>>> GetKeyCategories()
        {
            return await _context.KeyCategories.ToListAsync();
        }

        // GET: api/KeyCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyCategory>> GetKeyCategory(int id)
        {
            var keyCategory = await _context.KeyCategories.FindAsync(id);

            if (keyCategory == null)
            {
                return NotFound();
            }

            return keyCategory;
        }

        // PUT: api/KeyCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyCategory(int id, KeyCategory keyCategory)
        {
            if (id != keyCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(keyCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyCategoryExists(id))
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

        // POST: api/KeyCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KeyCategory>> PostKeyCategory(KeyCategory keyCategory)
        {
            _context.KeyCategories.Add(keyCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyCategory", new { id = keyCategory.Id }, keyCategory);
        }

        // DELETE: api/KeyCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyCategory(int id)
        {
            var keyCategory = await _context.KeyCategories.FindAsync(id);
            if (keyCategory == null)
            {
                return NotFound();
            }

            _context.KeyCategories.Remove(keyCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeyCategoryExists(int id)
        {
            return _context.KeyCategories.Any(e => e.Id == id);
        }
    }
}
