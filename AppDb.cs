using Microsoft.EntityFrameworkCore;

namespace EfCoreFKDemo
{
   public class AppDb : DbContext
   {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=app.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>(builder=>
            {
                builder.HasQueryFilter(x=>x.IsDeleted == false);
            });
        }

        public DbSet<Blog> Blogs{get;set;}

        public DbSet<Post> Posts{ get;set;}
 
   }
}