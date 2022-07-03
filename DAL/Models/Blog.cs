using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace DAL.Models
{
    public class Blog : BaseEntity, IEntity
    {
        public int ImageId { get; set; }
        public Image Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

