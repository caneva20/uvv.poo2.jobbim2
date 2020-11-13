using ajj.Models;
using Microsoft.EntityFrameworkCore;

namespace ajj.Data {
    public class Context : DbContext {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
