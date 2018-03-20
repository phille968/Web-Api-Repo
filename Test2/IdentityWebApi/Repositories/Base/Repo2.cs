using IdentityWebApi.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IdentityWebApi.Repositories.Base
{
    public class Repo2<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public Repo2(ApplicationDbContext context)
        {
            this.context = context;

        }
        public DbSet<T> Items => context.Set<T>();

        public void Add(T item)
        {
            Items.Add(item);
        }

        public void Edit(T item)
        {
            context.Entry(item).State = EntityState.Modified;

        }
        public T GetById(string id)
        {
            return Items.Find(id);

        }
        public void Remove(string id)
        {
            var entity = GetById(id);
            Items.Remove(entity);
        }
        public void SaveChanges(T item)
        {
            context.SaveChanges();
        }
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> text)
        {
            return Items.Where(text);
        }
        public IQueryable<T> ShowAll()
        {
            return Items;
        }
    }
}