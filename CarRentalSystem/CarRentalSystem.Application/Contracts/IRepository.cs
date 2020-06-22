using CarRentalSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IRepository<out TEntity>
        where TEntity : IAggregateRoot
    {
        IEnumerable<TEntity> All();

        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
