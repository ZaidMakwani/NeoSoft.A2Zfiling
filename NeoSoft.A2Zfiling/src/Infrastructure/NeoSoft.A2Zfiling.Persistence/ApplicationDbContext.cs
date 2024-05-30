using NeoSoft.A2Zfiling.Application.Contracts;
using NeoSoft.A2Zfiling.Domain.Common;
using NeoSoft.A2Zfiling.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Persistence
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Zones> Zones { get; set; }

        public DbSet<City> cities { get; set; }
        public DbSet<Roles> Roles { get; set; }
      
        public DbSet<Message> Messages { get; set; }

        public DbSet<Permission> Actions { get; set; }

        private IDbContextTransaction _transaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //seed data, added through migrations
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");


            modelBuilder.Entity<Roles>().HasData(new Roles { RoleId=1,RoleName="End User",IsActive=true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RoleId = 2,RoleName = "Executive", IsActive = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RoleId = 3,RoleName = "Field Executive", IsActive = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RoleId = 4,RoleName = "Vendor User", IsActive = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RoleId = 5,RoleName = "Alliance Manager", IsActive = true });
            modelBuilder.Entity<Roles>().HasData(new Roles { RoleId = 6,RoleName = "Admin", IsActive = true });





            modelBuilder.Entity<Message>()
                .Property(s => s.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{253C75D5-32AF-4DBF-AB63-1AF449BDE7BD}"),
                Code = "1",
                MessageContent = "{PropertyName} is required.",
                Language = "en",
                Type = Message.MessageType.Error
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{ED0CC6B6-11F4-4512-A441-625941917502}"),
                Code = "2",
                MessageContent = "{PropertyName} must not exceed {MaxLength} characters.",
                Language = "en",
                Type = Message.MessageType.Error
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{FAFE649A-3E2A-4153-8FD8-9DCD0B87E6D8}"),
                Code = "3",
                MessageContent = "An event with the same name and date already exists.",
                Language = "en",
                Type = Message.MessageType.Error
            });
        }


        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChangesAsync();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
