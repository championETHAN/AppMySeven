using CalendarProjectV1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CalendarProjectV1.Data
{
    public class CalendarProjectDbContext : DbContext
    {
        public CalendarProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CalendarItem> CalendarItems { get; set; }
    }
}
