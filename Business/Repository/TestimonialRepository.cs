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
    public class TestimonialRepository : ITestimonialService
    {
        private readonly AppDbContext _context;
        public TestimonialRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Testimonial> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }
            var data = await _context.Testimonials.Where(n => n.Id == id && !n.isDeleted)
                                             .Include(n => n.Image)
                                             .FirstOrDefaultAsync();
            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task<List<Testimonial>> GetAll()
        {
            var data = await _context.Testimonials.Where(n => !n.isDeleted).Include(n => n.Image).ToListAsync();
            if (data is null)
            {
                throw new EntityIsNullException();
            }
            return data;
        }

        public async Task Create(Testimonial entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Testimonials.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Testimonial entity)
        {
            var data = await Get(id);
            data.Text = entity.Text;
            data.UserId = entity.UserId;
            data.PositionId = entity.PositionId;
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

