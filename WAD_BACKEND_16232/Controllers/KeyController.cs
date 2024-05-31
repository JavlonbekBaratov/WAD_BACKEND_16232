using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_16232.Data.Migrations;
using WAD_BACKEND_16232.Models;
using WAD_BACKEND_16232.Repositories;

namespace WAD_BACKEND_16232.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        private readonly IKeyRepository _keyRepository;

        public KeysController(IKeyRepository keyRepository)
        {
            _keyRepository = keyRepository;
        }

        // GET: api/Keys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Key>>> GetKeys()
        {
            return new JsonResult(await _keyRepository.GetAllKeys(includeKeyCategory: true));
        }

        // GET: api/Keys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Key>> GetKey(int id)
        {
            var key = await _keyRepository.GetKeyById(id, includeKeyCategory: true);

            if (key == null)
            {
                return NotFound();
            }

            return key;
        }

        // POST: api/Keys
        [HttpPost]
        public async Task<ActionResult<Key>> PostKey(Key key)
        {
            await _keyRepository.CreateKey(key);

            // Include the KeyCategory information in the response
            await _keyRepository.LoadKeyCategory(key);

            return CreatedAtAction(nameof(GetKey), new { id = key.Id }, key);
        }

        // PUT: api/Keys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKey(int id, Key key)
        {
            if (id != key.Id)
            {
                return BadRequest();
            }

            try
            {
                await _keyRepository.UpdateKey(key);
            }
            catch (Exception)
            {
                if (!_keyRepository.KeyExists(id))
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

        // DELETE: api/Keys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKey(int id)
        {
            var key = await _keyRepository.GetKeyById(id);
            if (key == null)
            {
                return NotFound();
            }

            await _keyRepository.DeleteKey(id);

            return NoContent();
        }
    }
}
