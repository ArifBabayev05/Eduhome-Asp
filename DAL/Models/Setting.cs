using System;
using DAL.Entity;

namespace DAL.Models
{
    public class Setting : IEntity
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}

