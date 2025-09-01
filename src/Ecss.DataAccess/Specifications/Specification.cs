using Ecss.Domain.Interfaces.Specifications;
using System.Linq.Expressions;

namespace Ecss.DataAccess.Specifications;

public class Specification<T> : ISpecification<T>
{
    public Specification()
    {
    }

    public Specification(Expression<Func<T, bool>> where)
    {
        Where = where;
    }

    public Expression<Func<T, bool>>? Where { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = [];
    protected void AddIncludes(Expression<Func<T, object>> include)
    {
        Includes.Add(include);
    }
}
