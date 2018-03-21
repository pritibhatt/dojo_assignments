using System;
using System.ComponentModel.DataAnnotations;
namespace RESTauranter.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string ReviewerName { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        [MinLength(10)]
        public string Review { get; set; }
        [Required]
        [Range(1,5)]
        
        public int Stars {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DateValid (ErrorMessage="Field cannot be future date for")]
        public DateTime DateofVisit {get; set;}
        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate < DateTime.Now;
            }
        }
    }
}