using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.SeedWork
{
    public interface IRepository<T> where T : DomainEntity {
        Task<T> getById(int id);
        Task<IEnumerable<T>> getAll();
        void update(int id, T obj);
        void delete(int id);
        void add(T obj);
        void purge(int id);
    }
}
