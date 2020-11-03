using Microsoft.EntityFrameworkCore;

namespace ajj.Data {
    public class AppContext : DbContext {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    }
}
