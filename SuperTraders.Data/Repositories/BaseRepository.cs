using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperTraders.Core.Entities;
using SuperTraders.Data.Repositories.Infrastructure;
using SuperTraders.Presentation.Exceptions;

namespace SuperTraders.Data.Repositories
{
    public class BaseRepository<TModel> : IRepository<TModel> where TModel : BaseEntity
    {
        private readonly ApplicationContext _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<List<TModel>> All()
        {
            try
            {
                return await _context.Set<TModel>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<TModel> Get(string id)
        {
            try
            {
                TModel? model = await _context.Set<TModel>().SingleOrDefaultAsync(entity => entity.Id == id);
                if (model == null)
                {
                    throw new EntityNotFoundException();
                }

                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Find(Expression<Func<TModel, bool>> expression)
        {
            try
            {
                TModel? model = await _context.Set<TModel>().Where(expression).FirstOrDefaultAsync();
                if (model == null)
                {
                    throw new EntityNotFoundException();
                }

                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _context.Set<TModel>().Add(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Update(TModel model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                TModel? model = await _context.Set<TModel>().SingleOrDefaultAsync(entity => entity.Id == id);
                if (model == null)
                {
                    throw new EntityNotFoundException();
                }
                
                _context.Set<TModel>().Remove(model);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }
    }
}