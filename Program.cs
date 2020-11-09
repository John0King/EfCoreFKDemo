using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCoreFKDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            SeedData();
            var db = new AppDb();
            var query = db.Posts.Include(x => x.Blog);

            var count = query.Count();
            var result = query.ToList();

            Console.WriteLine($"there are counted  [{count}] posts");
            Console.WriteLine($"there are actually [{result.Count}] posts ");
            foreach (var p in result)
            {
                Console.WriteLine($"\tname:[{p.PostName }] blogId: [{p.BlogId}]  blog is deleted: { p.Blog?.IsDeleted ?? true }  ");
            }
        }

        static void SeedData()
        {
            var db = new AppDb();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var blog1 = new Blog
            {
                Name = "Blog - 1",
                IsDeleted = true,
            };
            var blog2 = new Blog
            {
                Name = "Blog - 2",
                IsDeleted = false,
            };

            var p1 = new Post
            {
                PostName = "b1 - p1",
                Blog = blog1,
            };
            var p2 = new Post
            {
                PostName = "b1 - p2",
                Blog = blog1,
            };
            var p3 = new Post
            {
                PostName = "b2 - p3",
                Blog = blog2,
            };

            db.AddRange(blog1, blog2);
            db.AddRange(p1, p2, p3);
            db.SaveChanges();
        }


    }
}
