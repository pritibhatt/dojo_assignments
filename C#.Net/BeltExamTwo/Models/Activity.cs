using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BeltExamTwo.Models
{
    public class Activity : BaseEntity
    {
      
        public int ActivityId {get; set;}
        [Required]
        [MinLength(2, ErrorMessage="Title must at least have two characters")]
        public string ActivityName {get; set;}
        [Required]
        public int Duration {get; set;}
        
        public string Description {get; set;}
        [Required]
        
        public string DescriptionTwo {get; set;}
        
        [Required]
        [DataType(DataType.Date)]
        [DateValid (ErrorMessage="Date must be a future date ")]
        public DateTime Date{get; set;}
        [Required]
        public DateTime Time {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Join> Join { get; set; }
       
        
        public Activity()
        {
            Join = new List<Join>();
        }
        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate > DateTime.Now;
            }
        }
        
    }
}