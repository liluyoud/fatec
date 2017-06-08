using Microsoft.EntityFrameworkCore;

namespace Fatec.Models
{
    public class FatecDb : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public FatecDb(DbContextOptions<FatecDb> options): base(options)
        {

        }
    }
}
