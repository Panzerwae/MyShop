using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        String className;
        public InMemoryRepository()
        {
            this.className = typeof(T).Name;
            this.items = cache[this.className] as List<T>;
            if (items == null) {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[this.className] = this.items;
        }

        public void Insert(T item)
        {
            this.items.Add(item);
        }

        public void Update(T item)
        {
            T itemToUpdate = this.items.Find(i => i.Id == item.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate = item;
            }
            else
            {
                throw new Exception(this.className + " not found to update");
            }
        }

        public T Find(String id)
        {
            T item = items.Find(i => i.Id == id);

            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception(this.className + " not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return this.items.AsQueryable();
        }

        public void Delete(String id)
        {
            T itemToDelete = items.Find(i => i.Id == id);

            if (itemToDelete != null)
            {
                this.items.Remove(itemToDelete);
            }
            else
            {
                throw new Exception(this.className + " not found to delete");
            }
        }
    }
}
