using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   // Checking App connection string
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=DESKTOP-HA42MEA\SQLEXPRESS; initial catalog=DemoApp;persist security info=True;user id=sa;password=Sql@1234; MultipleActiveResultSets=True; App=EntityFramework");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
