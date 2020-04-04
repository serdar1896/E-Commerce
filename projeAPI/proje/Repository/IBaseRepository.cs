using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.Repository
{
    interface IBaseRepository<T> where T : class, new()
    {
        void Delete(T entity);
        void Update(T entity);
        void Entry(T entity);
        Task<bool> Commit();
        Task<ICollection<T>> List();
        Task<T> Find(int id);
        DbSet<T> Set();

    }
}
