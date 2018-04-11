using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class AccountsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options) { }
         public DbSet<User> Users { get; set; }
         public DbSet<Transactions> Transaction { get; set; }
        
    }
}