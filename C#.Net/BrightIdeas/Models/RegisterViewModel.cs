using System.ComponentModel.DataAnnotations;

namespace BrightIdeas.Models
{
    public class RegisterViewModel : BaseEntity
    {
        
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress] 
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
       
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password and Confirm Password do not match")]
        public string ConfirmPassword {get; set;}
        
       
   
    }
}