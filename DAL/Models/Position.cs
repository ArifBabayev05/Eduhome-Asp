using System;
using System.ComponentModel.DataAnnotations;
using DAL.Entity;

namespace DAL.Models
{
    public class Position : IEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

