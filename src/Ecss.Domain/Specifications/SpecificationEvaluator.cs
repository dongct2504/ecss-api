﻿using Ecss.Domain.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Domain.Specifications;

public class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Where != null)
        {
            query = query.Where(spec.Where);
        }
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }
}
