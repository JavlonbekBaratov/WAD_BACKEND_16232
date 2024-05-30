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
    public class KeyController : ControllerBase
    {
        private readonly KeyStoreDbContext _context;

        public KeyController(KeyStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Key
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Key>>> GetKeys()
        {
            return await _context.Keys.ToListAsync();
        }

        // GET: api/Key/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Key>> GetKey(int id)
        {
            var key = await _context.Keys.FindAsync(id);

            if (key == null)
            {
                return NotFound();
            }

            return key;
        }

        // PUT: api/Key/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKey(int id, Key key)
        {
            if (id != key.Id)
            {
                return BadRequest();
            }

            _context.Entry(key).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyExists(id))
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

        // POST: api/Key
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Key>> PostKey(Key key)
        {
            _context.Keys.Add(key);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKey", new { id = key.Id }, key);
        }

        // DELETE: api/Key/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKey(int id)
        {
            var key = await _context.Keys.FindAsync(id);
            if (key == null)
            {
                return NotFound();
            }

            _context.Keys.Remove(key);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeyExists(int id)
        {
            return _context.Keys.Any(e => e.Id == id);
        }
    }
}
