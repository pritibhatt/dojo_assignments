using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class RegisterViewModel : BaseEntity
    {
        
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(4)]
        public string Alias { get; set; }
        
        [Required]
        [EmailAddress] 
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage="Email must be right format")]
       
        public string Email { get; set; }
        
        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password and Confirm Password do not match")]
        public string ConfirmPassword {get; set;}
    }    
    public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get;set; }
    }

       
   
    
}