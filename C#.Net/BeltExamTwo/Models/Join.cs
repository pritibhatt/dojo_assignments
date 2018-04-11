using System;
using System.ComponentModel.DataAnnotations;
namespace BeltExamTwo.Models
{
    public class Join : BaseEntity
    {
      
        public int JoinId {get; set;}
        public int ActivityId {get; set;}
        public Activity Activity {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
    }
}