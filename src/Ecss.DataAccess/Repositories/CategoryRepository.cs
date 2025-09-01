using Ecss.DataAccess.Data;
using Ecss.Domain.Entities;
using Ecss.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecss.DataAccess.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(EcssDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetByNameAsync(string name)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public void Update(Category category)
    {
        _context.Update(category);
    }
}
