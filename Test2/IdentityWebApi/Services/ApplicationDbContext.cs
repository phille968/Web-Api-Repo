using IdentityWebApi.Models;
using IdentityWebApi.Models.GroupItems;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IdentityWebApi.Services
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Section> Section { get; set; }
        public DbSet<PrivateMessage> PrivateMessage { get; set; }
        public DbSet<NewsPost> NewsPost { get; set; }

        public DbSet<Group> Group { get; set; }
        public DbSet<GroupMessage> GroupMessage { get; set; }
        public DbSet<GroupPost> GroupPost { get; set; }
        public DbSet<GroupEvent> GroupEvent { get; set; }
        public DbSet<Attending> Attending { get; set; }
        public DbSet<ActivationCode> ActivationCode { get; set; }

        public DbSet<Competition> Competition { get; set; }
        public DbSet<Challenges> Challenges { get; set; }
        // public DbSet<Result> Result { get; set; }
        public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<PrivateMessage>()
                .HasRequired(m => m.Reciever)
                .WithMany(t => t.PrivateMessageReciever)
                .HasForeignKey(m => m.RecieverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrivateMessage>()
                .HasRequired(m => m.Sender)
                .WithMany(t => t.PrivateMessageSender)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);
        }
    }
}