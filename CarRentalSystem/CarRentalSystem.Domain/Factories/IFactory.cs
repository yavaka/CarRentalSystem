using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Factories
{
    public interface IFactory<out TEntity>
    {
        TEntity Build();
    }
}
