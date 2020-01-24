using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.WebUI.Tests.Mocks
{
    class MockContext<T> : IRepository<T> where T : BaseEntity
    {
        List<T> entities;
        String entityClassName;
        public MockContext()
        {
            this.entities = new List<T>();
        }
        public void Commit()
        {
            return;
        }

        public void Insert(T entity)
        {
            this.entities.Add(entity);
        }

        public void Update(T entity)
        {
            T entityToUpdate = this.entities.Find(i => i.Id == entity.Id);

            if (entityToUpdate != null)
            {
                entityToUpdate = entity;
            }
            else
            {
                throw new Exception(this.entityClassName + " not found to update");
            }
        }

        public T Find(String id)
        {
            T entity = entities.Find(i => i.Id == id);

            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new Exception(this.entityClassName + " not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return this.entities.AsQueryable();
        }

        public void Delete(String id)
        {
            T entityToDelete = entities.Find(i => i.Id == id);

            if (entityToDelete != null)
            {
                this.entities.Remove(entityToDelete);
            }
            else
            {
                throw new Exception(this.entityClassName + " not found to delete");
            }
        }

}
}
