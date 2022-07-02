using System;
using DAL.Entity;

namespace DAL.Models
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

