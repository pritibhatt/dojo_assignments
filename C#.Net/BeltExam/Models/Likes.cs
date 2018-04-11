using System;
using System.ComponentModel.DataAnnotations;
namespace BeltExam.Models
{
    public class Like : BaseEntity
    {
      
        public int LikeId {get; set;}
        public int IdeaId {get; set;}
        public Idea Idea {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
    }
}