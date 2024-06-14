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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NeoSoft.A2Zfiling.Persistence
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<SubStatus> SubStatuses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Zones> Zones { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Role { get; set; }               
        public DbSet<PinCode> Pincodes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MunicipalCorp> MunicipalCorporations { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Permission> Permission { get; set; }

        public DbSet<UserPermission> User { get; set; }

        private IDbContextTransaction _transaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //seed data, added through migrations
            //var concertguid = guid.parse("{b0788d2f-8003-43c1-92a4-edc76a7c5dde}");
            //var musicalguid = guid.parse("{6313179f-7837-473a-a4d5-a5571b43e6a6}");
            //var playguid = guid.parse("{bf3f3002-7e53-441e-8b76-f6280be284aa}");
            //var conferenceguid = guid.parse("{fe98f549-e790-4e9f-aa16-18c2292a2ee9}");
            modelBuilder.Entity<Zones>().HasKey(z => z.ZoneId);
            modelBuilder.Entity<State>().HasKey(s => s.StateId);
            modelBuilder.Entity<City>().HasKey(c => c.CityId);
            modelBuilder.Entity<Domain.Entities.MunicipalCorp>().HasKey(mc => mc.MunicipalId);

            // Configure relationships
            modelBuilder.Entity<City>()
             .HasOne(c => c.State)
             .WithMany(s => s.Cities)
             .HasForeignKey(c => c.StateId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Zones)
                .WithMany(z => z.Cities)
                .HasForeignKey(c => c.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure MunicipalCorp relationships
            modelBuilder.Entity<MunicipalCorp>()
                .HasOne(m => m.Zones)
                .WithMany(z => z.MunicipalCorps)
                .HasForeignKey(m => m.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MunicipalCorp>()
                .HasOne(m => m.City)
                .WithMany(c => c.MunicipalCorps)
                .HasForeignKey(m => m.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

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
