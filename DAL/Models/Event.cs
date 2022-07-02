using System;
using DAL.Base;
using DAL.Entity;

namespace DAL.Models
{
    public class Event : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public int  CityId{ get; set; }
        public City City { get; set; }
    }
}

