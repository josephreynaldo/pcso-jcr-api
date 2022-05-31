using Microsoft.EntityFrameworkCore;
using pcso_jcr_api.Models;

namespace pcso_jcr_api.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Sector> Sectors { get; set; }
    }

}
