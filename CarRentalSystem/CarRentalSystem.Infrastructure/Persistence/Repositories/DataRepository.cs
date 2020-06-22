using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    internal class DataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        private readonly CarRentalDbContext _dbContext;


        public DataRepository(CarRentalDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public IEnumerable<TEntity> All()
        {
            return this._dbContext.Set<TEntity>();
        }

        public Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
