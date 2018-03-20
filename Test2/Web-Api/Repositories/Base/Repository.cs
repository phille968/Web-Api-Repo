using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Web_Api.Services;

namespace Web_Api.Repositories.Base
{
    public class Repository<T> where T : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;

        }
        public DbSet<T> Items => context.Set<T>();

        public void Edit (T item)
        {
            context.Entry(item).State = EntityState.Modified;

        }
        public T GetById(int id)
        {
            return Items.Find(id);

        }
        public void Remove(int id)
        {
            var entity = GetById(id);
            Items.Remove(entity);
        }
        public IQueryable<T> SearhFor(Expression<Func<T,bool>> text)
        {
            return Items.Where(text);
        }
        public IQueryable<T> ShowAll()
        {
            return Items;
        }
    }
}