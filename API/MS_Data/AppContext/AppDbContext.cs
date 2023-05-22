using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.Relations.ManyToMany;
using MS_Models.Relations.OneToMany;
using MS_Models.Relations.OneToOne;
using MS_Models.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MS_Data.AppContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<EmailPlaceholder> EmailPlaceholders { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<SessionLog> SessionLog { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassSection> ClassSections { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<FeeStructure> FeeStructures { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //One To One
            builder.Entity<Organization>().HasOne(c => c.Campus).WithOne(pa => pa.Organization).HasForeignKey<Campus>(pa => pa.OrganizationId);
            builder.Entity<Students>().HasOne(c => c.StudentDetail).WithOne(pa => pa.Students).HasForeignKey<StudentDetail>(pa => pa.StudentId);
            builder.Entity<Students>().HasOne(c => c.Enrollments).WithOne(pa => pa.Students).HasForeignKey<Enrollments>(pa => pa.StudentId);

            //One To Many
            builder.Entity<Campus>().HasMany(c => c.ClassSection).WithOne(w => w.Campus);
            builder.Entity<Session>().HasMany(c => c.ClassSection).WithOne(w => w.Session);
            builder.Entity<Section>().HasMany(c => c.ClassSection).WithOne(w => w.Section);
            builder.Entity<Class>().HasMany(c => c.ClassSection).WithOne(w => w.Class);
            builder.Entity<Students>().HasMany(c => c.ClassSection).WithOne(w => w.Students);
            builder.Entity<FeeStructure>().HasMany(c => c.ClassSection).WithOne(w => w.FeeStructure);

            builder.Entity<Campus>().HasMany(c => c.FeeStructure).WithOne(w => w.Campus);
            builder.Entity<Session>().HasMany(c => c.FeeStructure).WithOne(w => w.Session);
            builder.Entity<Class>().HasMany(c => c.FeeStructure).WithOne(w => w.Class);
            builder.Entity<Section>().HasMany(c => c.FeeStructure).WithOne(w => w.Section);

            //Many To Many
            //builder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
            //builder.Entity<BookCategory>().HasOne(bc => bc.Book).WithMany(b => b.BookCategories).HasForeignKey(bc => bc.BookId);
            //builder.Entity<BookCategory>().HasOne(bc => bc.Category).WithMany(c => c.BookCategories).HasForeignKey(bc => bc.CategoryId);
                      
        }
    }
}
