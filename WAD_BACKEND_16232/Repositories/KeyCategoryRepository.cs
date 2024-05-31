using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_16232.Data.Migrations;
using WAD_BACKEND_16232.Models;

namespace WAD_BACKEND_16232.Repositories
{
    public class KeyCategoryRepository : IKeyCategoryRepository
    {
        private readonly KeyStoreDbContext _dbContext;
        private readonly ILogger<KeyCategoryRepository> _logger;

        public KeyCategoryRepository(KeyStoreDbContext dbContext, ILogger<KeyCategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<KeyCategory>> GetAllKeyCategories()
        {
            try
            {
                return await _dbContext.KeyCategories.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving key categories");
                throw;
            }
        }

        public async Task<KeyCategory> GetKeyCategoryById(int id)
        {
            try
            {
                return await _dbContext.KeyCategories.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving key category with ID {id}");
                throw;
            }
        }

        public async Task CreateKeyCategory(KeyCategory keyCategory)
        {
            if (keyCategory == null)
            {
                throw new ArgumentNullException(nameof(keyCategory));
            }

            try
            {
                await _dbContext.KeyCategories.AddAsync(keyCategory);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error occurred while creating key category: {ex.Message}");
                throw new Exception("Failed to create key category. Please check the provided data.");
            }
        }

        public async Task UpdateKeyCategory(KeyCategory keyCategory)
        {
            if (keyCategory == null)
            {
                throw new ArgumentNullException(nameof(keyCategory));
            }

            try
            {
                _dbContext.Entry(keyCategory).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, $"Error occurred while updating key category: {ex.Message}");
                throw new Exception("Failed to update key category due to concurrency conflict.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating key category: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteKeyCategory(int id)
        {
            try
            {
                var keyCategory = await _dbContext.KeyCategories.FirstOrDefaultAsync(x => x.Id == id);
                if (keyCategory != null)
                {
                    _dbContext.Remove(keyCategory);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting key category with ID: {id}");
                throw;
            }
        }

        public bool KeyCategoryExists(int id)
        {
            return _dbContext.KeyCategories.Any(e => e.Id == id);
        }
    }
}
