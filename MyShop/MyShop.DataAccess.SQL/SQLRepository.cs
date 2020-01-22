using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository <T> : IRepository<T> where T: BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext dataContext)
        {
            this.context = dataContext;
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return this.dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = Find(id);
            if (context.Entry(entity).State == EntityState.Detached) 
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public T Find(string id)
        {
            return this.dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
