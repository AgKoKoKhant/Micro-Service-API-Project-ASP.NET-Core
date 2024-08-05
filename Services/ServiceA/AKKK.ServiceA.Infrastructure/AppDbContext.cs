using Microsoft.EntityFrameworkCore;
using Alpha.ServiceA.Model;

namespace Alpha.ServiceA.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
    }
}
