using System;
using System.Collections.Generic;
namespace WeddingPlanner.Models
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
       
        public List<RSVP> RSVP { get; set; }
 
        public User()
        {
            RSVP = new List<RSVP>();
        }
    }
    

}