
namespace WAD_BACKEND_16232.Repositories
{
    public class KeyRepository : IKeyRepository
    {
        public Task CreateKey(Key key)
        {
            throw new NotImplementedException();
        }

        public Task DeleteKey(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Key>> GetAllKeys(bool includeKeyCategory = false)
        {
            throw new NotImplementedException();
        }

        public Task<Key> GetKeyById(int id, bool includeKeyCategory = false)
        {
            throw new NotImplementedException();
        }

        public bool KeyExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task LoadKeyCategory(Key key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateKey(Key key)
        {
            throw new NotImplementedException();
        }
    }
}
