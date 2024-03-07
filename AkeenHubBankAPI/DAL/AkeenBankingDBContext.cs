using AkeenHubBankAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AkeenHubBankAPI.DAL
{
    public class AkeenBankingDBContext : DbContext
    {
        public AkeenBankingDBContext(DbContextOptions<AkeenBankingDBContext>options): base(options) 
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
