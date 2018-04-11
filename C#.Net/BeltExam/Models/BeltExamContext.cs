using Microsoft.EntityFrameworkCore;
 
namespace BeltExam.Models
{
    public class BeltExamContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltExamContext(DbContextOptions<BeltExamContext> options) : base(options) { }
         public DbSet<User> Users { get; set; }
         public DbSet<Idea> Ideas { get; set; }
         public DbSet<Like> Likes { get; set; }


        
    }
}