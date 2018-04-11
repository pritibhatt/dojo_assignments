using System;
using System.Collections.Generic;
namespace BrightIdeas.Models
{
    public abstract class BaseEntity
    {
    }
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        // public User()
        // {
        //     Like = new List<Like>();
        // }
       
    }
    

}