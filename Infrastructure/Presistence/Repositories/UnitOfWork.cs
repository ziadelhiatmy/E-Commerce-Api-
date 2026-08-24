using DomainLayer.Contracts;
using DomainLayer.Models;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUniteOfWork
    {
        private readonly Dictionary<string, object> _repository = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var TypeName = typeof(TEntity).Name;
            if (_repository.TryGetValue(TypeName , out object? value))
                return (IGenericRepository<TEntity, TKey>) value;
            else
            {
                var Repo = new GenericRepository<TEntity, TKey>(_dbContext);
                _repository[TypeName] = Repo;
                return Repo;
            
            }
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    }
}
