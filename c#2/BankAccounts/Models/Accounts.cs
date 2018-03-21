using System;
using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class Accounts : BaseEntity
    {
        
        [Required]
        
        public int CurrentBalance { get; set; }
        
        [Required]
        
        public int DepositWithdraw { get; set; }
        
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        
    }
}