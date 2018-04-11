using Microsoft.EntityFrameworkCore;
 
namespace BeltExamTwo.Models
{
    public class BeltExamTwoContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltExamTwoContext(DbContextOptions<BeltExamTwoContext> options) : base(options) { }
         public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
         public DbSet<Join> Joins { get; set; }

        
    }
}