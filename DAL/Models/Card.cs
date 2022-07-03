using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace DAL.Models
{
    public class Card : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}

