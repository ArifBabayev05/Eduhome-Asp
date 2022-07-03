using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace DAL.Models
{
    public class Testimonial : BaseEntity, IEntity 
    {
        public string Text { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        public User User{ get; set; }
        public int UserId { get; set; }

        public Position Position { get; set; }
        public int PositionId { get; set; }


    }
}

