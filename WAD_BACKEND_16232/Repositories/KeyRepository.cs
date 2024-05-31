
using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_16232.Data.Migrations;
using WAD_BACKEND_16232.Models;

namespace WAD_BACKEND_16232.Repositories
{
    public class KeyRepository : IKeyRepository
    {
        private readonly KeyStoreDbContext _dbContext;

        public KeyRepository(KeyStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Key>> GetAllKeys(bool includeKeyCategory = false)
        {
            try
            {
                if (includeKeyCategory)
                {
                    return await _dbContext.Keys.Include(k => k.KeyCategory).ToListAsync();
                }
                else
                {
                    return await _dbContext.Keys.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Error occurred while retrieving keys.", ex);
            }
        }


        public async Task<Key> GetKeyById(int id, bool includeKeyCategory = false)
        {
            try
            {
                if (includeKeyCategory)
                {
                    return await _dbContext.Keys.Include(k => k.KeyCategory).FirstOrDefaultAsync(k => k.Id == id);
                }
                else
                {
                    return await _dbContext.Keys.FirstOrDefaultAsync(k => k.Id == id);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while retrieving key with ID {id}.", ex);
            }
        }

        public async Task CreateKey(Key key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            try
            {
                _dbContext.Keys.Add(key);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Failed to create key. Please check the provided data.", ex);
            }
        }

        public async Task UpdateKey(Key key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            try
            {
                _dbContext.Entry(key).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while updating key with ID {key.Id}.", ex);
            }
        }

        public async Task DeleteKey(int id)
        {
            try
            {
                var key = await _dbContext.Keys.FirstOrDefaultAsync(k => k.Id == id);
                if (key != null)
                {
                    _dbContext.Keys.Remove(key);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while deleting key with ID {id}.", ex);
            }
        }

        public bool KeyExists(int id)
        {
            return _dbContext.Keys.Any(k => k.Id == id);
        }

        public async Task LoadKeyCategory(Key key)
        {
            await _dbContext.Entry(key).Reference(k => k.KeyCategory).LoadAsync();
        }
    }
}
