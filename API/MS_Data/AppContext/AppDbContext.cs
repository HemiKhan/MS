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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmailPlaceholder> EmailPlaceholders { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<SessionLog> SessionLog { get; set; }



        //Manay To Many Relation
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        //One To Many Relation
        public DbSet<Company> Companies { get; set; }
        public DbSet<Worker> Workers { get; set; }
        //One To One Relation
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().HasKey(x => x.EmpID);

            //Many To Many
            builder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.Entity<BookCategory>().HasOne(bc => bc.Book).WithMany(b => b.BookCategories).HasForeignKey(bc => bc.BookId);
            builder.Entity<BookCategory>().HasOne(bc => bc.Category).WithMany(c => c.BookCategories).HasForeignKey(bc => bc.CategoryId);

            //One To Many
            builder.Entity<Company>().HasMany(c => c.Workers).WithOne(w => w.Company);

            //One To One
            builder.Entity<Customer>().HasOne(c => c.Address).WithOne(pa => pa.Customer).HasForeignKey<PostalAddress>(pa => pa.CustomerId);
        }




    }
}
