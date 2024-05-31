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
    public class KeyCategoriesController : ControllerBase
    {
        private readonly IKeyCategoryRepository _keyCategoryRepository;

        public KeyCategoriesController(IKeyCategoryRepository keyCategoryRepository)
        {
            _keyCategoryRepository = keyCategoryRepository;
        }

        // GET: api/KeyCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeyCategory>>> GetKeyCategories()
        {
            return new JsonResult(await _keyCategoryRepository.GetAllKeyCategories());
        }

        // GET: api/KeyCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyCategory>> GetKeyCategory(int id)
        {
            var keyCategory = await _keyCategoryRepository.GetKeyCategoryById(id);

            if (keyCategory == null)
            {
                return NotFound();
            }

            return keyCategory;
        }

        // POST: api/KeyCategories
        [HttpPost]
        public async Task<ActionResult<KeyCategory>> PostKeyCategory(KeyCategory keyCategory)
        {
            await _keyCategoryRepository.CreateKeyCategory(keyCategory);

            return CreatedAtAction(nameof(GetKeyCategory), new { id = keyCategory.Id }, keyCategory);
        }

        // PUT: api/KeyCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyCategory(int id, KeyCategory keyCategory)
        {
            if (id != keyCategory.Id)
            {
                return BadRequest();
            }

            try
            {
                await _keyCategoryRepository.UpdateKeyCategory(keyCategory);
            }
            catch (Exception)
            {
                if (!_keyCategoryRepository.KeyCategoryExists(id))
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

        // DELETE: api/KeyCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyCategory(int id)
        {
            var keyCategory = await _keyCategoryRepository.GetKeyCategoryById(id);
            if (keyCategory == null)
            {
                return NotFound();
            }

            await _keyCategoryRepository.DeleteKeyCategory(id);

            return NoContent();
        }
    }
}
