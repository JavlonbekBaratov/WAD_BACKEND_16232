using WAD_BACKEND_16232.Models;

namespace WAD_BACKEND_16232.Repositories
{
    public interface IKeyRepository
    {
        Task<IEnumerable<Key>> GetAllKeys(bool includeKeyCategory = false);
        Task<Key> GetKeyById(int id, bool includeKeyCategory = false);
        Task CreateKey(Key key);
        Task UpdateKey(Key key);
        Task DeleteKey(int id);
        Task LoadKeyCategory(Key key);
        bool KeyExists(int id);
    }
}
