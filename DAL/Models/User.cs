using System;
using DAL.Entity;

namespace DAL.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}

