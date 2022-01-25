using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SuperTraders.Core.Entities;

namespace SuperTraders.Data.Repositories.Infrastructure
{
    public interface IRepository<TModel> where TModel : BaseEntity
    {
        Task<List<TModel>> All();

        Task<TModel> Get(string id);

        Task<TModel> Find(Expression<Func<TModel, bool>> expression);

        Task<TModel> Create(TModel entity);

        Task<TModel> Update(TModel entity);

        Task Delete(string id);
    }
}