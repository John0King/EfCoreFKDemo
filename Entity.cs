
namespace EfCoreFKDemo
{
    public class Blog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string PostName { get; set; }

        // with goal 3 , so I define that the BlogId is requred
        public int BlogId { get; set; }

        public Blog Blog{ get;set;}
    }
}
