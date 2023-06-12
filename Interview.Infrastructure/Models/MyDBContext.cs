using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastructure.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
         : base(options)
        {
        }
    }
}