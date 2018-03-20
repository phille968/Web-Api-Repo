using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApi.Models;
using System.Data.SqlTypes;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApi.Services
{
    public partial class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {

        }
        public DbSet<User> TestUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<PrivateMessage>()
            //    .HasRequired(m => m.Reciever)
            //    .WithMany(t => t.MessageReciever)
            //    .HasForeignKey(m => m.ReciverId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PrivateMessage>()
            //    .HasRequired(m => m.Sender)
            //    .WithMany(t => t.MessageSender)
            //    .HasForeignKey(m => m.SenderId)
            //    .WillCascadeOnDelete(false);
        }
    }
}