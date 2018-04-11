using System;
namespace BankAccounts.Models
{
    public abstract class BaseEntity
    {
    }
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        public double CurrentBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User()
        {
            CurrentBalance=0;
        }
    }

}