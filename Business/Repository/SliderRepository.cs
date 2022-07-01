using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
    public class SliderRepository : ISliderService
    {
        private readonly AppDbContext _context;
        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Slider> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _context.Sliders.Where(n => n.Id == id && !n.isDeleted).FirstOrDefaultAsync();
            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task<List<Slider>> GetAll()
        {
            var data = await _context.Sliders.Where(n =>!n.isDeleted).ToListAsync();
            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task Create(Slider entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Sliders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Slider entity)
        {
            var data = await Get(id);
            data.Body = entity.Body;
            data.Title = entity.Title;
            data.ImageId = entity.ImageId;
            data.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

        }
        public async Task Delete(int id)
        {
            var data = await Get(id);
            data.isDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}

