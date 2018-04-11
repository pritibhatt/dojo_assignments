using System;
using System.ComponentModel.DataAnnotations;
namespace loginRegistration.Models
{
    
    public abstract class BaseEntity
    {
    }
    public class User : BaseEntity
    
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress] 
        [RegularExpression(@"^[a-zA-Z]+$")]   
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password and Confirm Password do not match")]
        public string Confirm {get; set;}
    }

     public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password{get;set;}
    }
}