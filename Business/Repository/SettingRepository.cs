using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace Business.Repository
{
    public class SettingRepository
    {
        
        private readonly Dictionary<string, string> _keyValues;

        public SettingRepository(AppDbContext context)
        {
            _keyValues = context.Settings.ToDictionary(n => n.Key, n => n.Value);
        }


        public string Get(string key)
        {
            var data = _keyValues[key];
            return data;
        }

        public Dictionary<string,string>  GetALl()
        {
            var data = _keyValues;
            return data;
        }

        //public Task Create(Setting entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        

        //public Task Update(int id, Setting entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

