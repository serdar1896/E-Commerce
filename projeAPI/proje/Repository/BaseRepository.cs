using Microsoft.EntityFrameworkCore;
using proje.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        DatabaseContext _db;
        public BaseRepository(DatabaseContext db)//ctor serviste tanımladığımız context
        {
            _db = db;
        }//newlemiş oluyoruz
        public async Task<bool> Commit()
        {
            return await _db.SaveChangesAsync() > 0;
            //try
            //{
            //    await _db.SaveChangesAsync();
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        public void Delete(T entity)
        {
            _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Entry(T entity)
        {
            _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public async Task<T> Find(int id)
        {
            return await Set().FindAsync(id);
        }

        public async Task<ICollection<T>> List()
        {
            return await Set().ToListAsync();
        }
        public Microsoft.EntityFrameworkCore.DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
