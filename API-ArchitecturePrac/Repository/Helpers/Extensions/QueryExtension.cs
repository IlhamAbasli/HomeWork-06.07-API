﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helpers.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if(includes is not null)
            {
                query = includes.Aggregate(query,(current,include) => current.Include(include));
            }
            return query;
        }
    }
}
