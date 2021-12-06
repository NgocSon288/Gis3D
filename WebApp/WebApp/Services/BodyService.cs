using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Entities;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Faces;

namespace WebApp.Services
{
    public class BodyService : BaseService, IBodyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public BodyService(ApplicationDbContext context, 
            IConfiguration configuration):base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<BodyViewModel>> GetAll()
        {
            var bodies = await _context.Bodies
                .Include(x => x.Faces)
                .ToListAsync();

            var bodiesVm = bodies.Select(x => new BodyViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Faces = x.Faces.Select(f => new FaceViewModel()
                {
                    Id = f.Id
                }).ToList(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy
            }).ToList();

            return bodiesVm;
        }

        public async Task<BodyUpdateRequest> GetById(int bodyId)
        {
            var body = await _context.Bodies 
                .FirstOrDefaultAsync(x => x.Id == bodyId);

            var bodyVm = new BodyUpdateRequest()
            {
                Id = body.Id,
                Name = body.Name,
                Description = body.Description
            };

            return bodyVm;
        }

        public async Task<bool> Create(BodyCreateRequest request)
        {
            var body = new Body()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedBy = base.GetOwner(),
                CreatedAt = DateTime.Now,
                UpdatedBy = null,
                UpdatedAt = null
            };

            await _context.AddAsync(body);
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Update(int bodyId, BodyUpdateRequest request)
        {
            var body = await _context.Bodies
                .FirstOrDefaultAsync(x => x.Id == bodyId);

            if (body == null)
            {
                return false;
            }

            body.Name = request.Name;
            body.Description = request.Description;
            body.UpdatedBy = base.GetOwner();
            body.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int bodyId)
        {
            var body = await _context.Bodies
                .FirstOrDefaultAsync(x => x.Id == bodyId);

            if (body == null)
            {
                return false;
            }

             _context.Remove(body);
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }
         
    }
}
