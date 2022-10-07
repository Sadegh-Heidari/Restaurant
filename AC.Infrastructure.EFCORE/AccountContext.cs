using Domain;
using Microsoft.EntityFrameworkCore;

namespace AC.Infrastructure.EFCORE
{
    public class AccountContext:DbContext
    {
        public DbSet<Account> acc { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }
    }
}