using System;
using DAL.Entity;

namespace DAL.Models
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

