using System;
using DAL.Base;
using DAL.Entity;

namespace DAL.Models
{
    public class Card : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}

