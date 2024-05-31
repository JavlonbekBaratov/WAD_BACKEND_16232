using WAD_BACKEND_16232.Models;

namespace WAD_BACKEND_16232.Repositories
{
    public interface IKeyCategoryRepository
    {
        Task<IEnumerable<KeyCategory>> GetAllKeyCategories();
        Task<KeyCategory> GetKeyCategoryById(int id);
        Task CreateKeyCategory(KeyCategory keyCategory);
        Task UpdateKeyCategory(KeyCategory keyCategory);
        Task DeleteKeyCategory(int id);
        bool KeyCategoryExists(int id);
    }
}
