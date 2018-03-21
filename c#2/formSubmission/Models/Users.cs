using System;
using System.ComponentModel.DataAnnotations;
namespace formSubmission.Models
{
    public class User : BaseEntity
    
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
        
        [Required]
        [Range(1, 200)]
        public int Age { get; set; }  
       
        [Required]
        [EmailAddress]    
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }

    public abstract class BaseEntity
    {
    }
}