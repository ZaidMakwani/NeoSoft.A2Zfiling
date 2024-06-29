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

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<DocumentDetail> DocumentDetails { get; set; }

        public DbSet<DocumentMaster> DocumentMasters { get; set; }


        public DbSet<SubStatus> SubStatuses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<LicenseMaster> LicenseMaster { get; set; }
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

            //License Mapping
            modelBuilder.Entity<LicenseMaster>(entity =>
            {
                entity.HasKey(e => e.LicenceMasterId);

                entity.Property(e => e.LicenseName)
                    .HasMaxLength(50);

                entity.Property(e => e.Classification)
                    .HasMaxLength(50);

                entity.Property(e => e.StandardRate)
                    .HasMaxLength(20);

                entity.Property(e => e.StandardTAT)
                    .HasMaxLength(20);

                entity.Property(e => e.FastTrackRate)
                    .HasMaxLength(20);

                entity.Property(e => e.FastTrackTAT)
                    .HasMaxLength(20);

                entity.HasOne(e => e.City)
                    .WithMany(c => c.LicenseMasters)
                    .HasForeignKey(e => e.CityId);

                entity.HasOne(e => e.MunicipalCorp)
                    .WithMany(mc => mc.LicenseMasters)
                    .HasForeignKey(e => e.MunicipalId);

                entity.HasOne(e => e.State)
                    .WithMany(s => s.LicenseMasters)
                    .HasForeignKey(e => e.StateId);

                entity.HasOne(e => e.Zones)
                    .WithMany(z => z.LicenseMasters)
                    .HasForeignKey(e => e.ZoneId);

                entity.HasOne(e => e.Industry)
                    .WithMany(i => i.LicenseMasters)
                    .HasForeignKey(e => e.IndustryId);

                entity.HasOne(e => e.Company)
                   .WithMany(i => i.LicenseMasters)
                   .HasForeignKey(e => e.CompanyId);
            });
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId);
                entity.HasMany(c => c.LicenseMasters)
                    .WithOne(lm => lm.City)
                    .HasForeignKey(lm => lm.CityId);
            });

            modelBuilder.Entity<MunicipalCorp>(entity =>
            {
                entity.HasKey(e => e.MunicipalId);
                entity.HasMany(mc => mc.LicenseMasters)
                    .WithOne(lm => lm.MunicipalCorp)
                    .HasForeignKey(lm => lm.MunicipalId);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateId);
                entity.HasMany(s => s.LicenseMasters)
                    .WithOne(lm => lm.State)
                    .HasForeignKey(lm => lm.StateId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<Zones>(entity =>
            {
                entity.HasKey(e => e.ZoneId);
                entity.HasMany(z => z.LicenseMasters)
                    .WithOne(lm => lm.Zones)
                    .HasForeignKey(lm => lm.ZoneId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasKey(e => e.IndustryId);
                entity.HasMany(z => z.LicenseMasters)
                    .WithOne(lm => lm.Industry)
                    .HasForeignKey(lm => lm.IndustryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId);
                entity.HasMany(z => z.LicenseMasters)
                    .WithOne(lm => lm.Company)
                    .HasForeignKey(lm => lm.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<LicenseMaster>()
                .HasOne(lm => lm.License)
                .WithMany()
                .HasForeignKey(lm => lm.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<License>(entity =>
            {
                entity.HasKey(e => e.LicenseId);
                entity.HasMany(z=>z.LicenseMasters)
                    .WithOne(lm => lm.License)
                    .HasForeignKey(lm => lm.LicenseId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
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
