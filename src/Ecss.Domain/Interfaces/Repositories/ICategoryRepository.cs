using Ecss.Domain.Entities;

namespace Ecss.Domain.Interfaces.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByNameAsync(string name);
    void Update(Category category);
}
