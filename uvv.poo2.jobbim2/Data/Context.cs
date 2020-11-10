using ajj.Models;
using Microsoft.EntityFrameworkCore;

namespace ajj.Data {
    public class Context : DbContext {
        public DbSet<Employee> Employees { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
