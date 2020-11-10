using Microsoft.EntityFrameworkCore;

namespace ajj.Data {
    public class Context : DbContext {
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
