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
    public class EventRepository : IEventService
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Event> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _context.Events.Where(n => n.Id == id && !n.isDeleted)
                                             .Include(n => n.City)
                                             .FirstOrDefaultAsync();
            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task<List<Event>> GetAll()
        {
            var data = await _context.Events.Where(n => !n.isDeleted).Include(n => n.City).ToListAsync();
            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task Create(Event entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Events.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Event entity)
        {
            var data = await Get(id);
            data.Title = entity.Title;
            data.City = entity.City;
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

