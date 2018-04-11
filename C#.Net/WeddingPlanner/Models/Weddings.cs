using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
      
        public int WeddingId {get; set;}
        [Required]
        public string WedderOne{get; set;}
        [Required]
        public string WedderTwo{get; set;}
        [Required]
        public string WeddingAddress{get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DateValid (ErrorMessage="Date must be a future date ")]
        public DateTime Date {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<RSVP> RSVP { get; set; }
       
        
        public Wedding()
        {
            RSVP = new List<RSVP>();
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