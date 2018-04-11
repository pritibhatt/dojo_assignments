using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BrightIdeas.Models
{
    public class Idea : BaseEntity
    {
      
        public int IdeaId {get; set;}
        [Required]
        public string NewIdea {get; set;}
        [Required]
        
        public int UserId {get; set;}
        public User User {get; set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Like> Like { get; set; }
       
        
        public Idea()
        {
            Like = new List<Like>();
        }
       
    }
}