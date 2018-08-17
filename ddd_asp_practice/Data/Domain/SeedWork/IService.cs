using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.SeedWork {
    public interface IService<T> where T : IViewModel {
        void add(T model);
        void update(T model);
        void delete(int id);
        T getById(int id);
        IEnumerable<T> getAll();
    }
}
