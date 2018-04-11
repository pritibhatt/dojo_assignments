using System;
using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class Transactions : BaseEntity
    {
        [Key]
        public int TransactionsId {get; set;}
       
        
        [Required]
       
        public int Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        
    }
}