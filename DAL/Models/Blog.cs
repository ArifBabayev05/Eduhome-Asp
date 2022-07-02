using System;
using DAL.Base;
using DAL.Entity;

namespace DAL.Models
{
    public class Blog : BaseEntity, IEntity
    {
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

