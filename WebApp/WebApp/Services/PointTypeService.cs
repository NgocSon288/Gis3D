using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Entities;
using WebApp.ViewModels.PointTypeOptions;
using WebApp.ViewModels.PointTypes;
using WebApp.ViewModels.Options;

namespace WebApp.Services
{
    public class PointTypeService : BaseService, IPointTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PointTypeService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<PointTypeViewModel>> GetAll()
        {
            var pointTypes = await _context.PointTypes.ToListAsync();

            return pointTypes.Select(x => new PointTypeViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedAt = x.UpdatedAt,
                UpdatedBy = x.UpdatedBy
            }).ToList();
        }

        public async Task<PointTypeCreateRequest> GetById(int pointTypeId)
        {
            var pointType = await _context.PointTypes
                .Include(x => x.PointTypeOptions)
                .FirstOrDefaultAsync(x => x.Id == pointTypeId);
            var options = await _context.Options.ToListAsync();

            return new PointTypeCreateRequest()
            {
                Id = pointType.Id,
                Name = pointType.Name,
                Description = pointType.Description,
                CreatedAt = pointType.CreatedAt,
                CreatedBy = pointType.CreatedBy,
                UpdatedAt = pointType.UpdatedAt,
                UpdatedBy = pointType.UpdatedBy,
                PointTypeOptions = options.Select(x => new PointTypeOptionCreateRequest()
                {
                    OptionId = x.Id,
                    IsCheckd = pointType.PointTypeOptions.Any(lto => lto.OptionId == x.Id)
                }).ToList()
            };
        }

        public async Task<PointTypeCreateRequest> GetFirstPointType()
        {
            var pointType = await _context.PointTypes
                .Include(x => x.PointTypeOptions)
                .FirstOrDefaultAsync();
            var options = await _context.Options.ToListAsync();

            return new PointTypeCreateRequest()
            {
                Id = pointType.Id,
                Name = pointType.Name,
                Description = pointType.Description,
                CreatedAt = pointType.CreatedAt,
                CreatedBy = pointType.CreatedBy,
                UpdatedAt = pointType.UpdatedAt,
                UpdatedBy = pointType.UpdatedBy,
                PointTypeOptions = options.Select(x => new PointTypeOptionCreateRequest()
                {
                    OptionId = x.Id,
                    IsCheckd = pointType.PointTypeOptions.Any(lto => lto.OptionId == x.Id)
                }).ToList()
            };
        }

        public async Task<List<PointTypeOptionViewModel>> GetPointTypeOptionByPointTypeId(int pointTypeId)
        {
            var pointTypeOptions = await _context.PointTypeOptions
                .Include(x => x.Option)
                .Where(x => x.PointTypeId == pointTypeId)
                .ToListAsync();

            return pointTypeOptions.Select(x => new PointTypeOptionViewModel()
            {
                Id = x.Id,
                OptionId = x.OptionId,
                Option = new OptionViewModel()
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                }
            }).ToList();
        }

        public async Task<bool> Create(PointTypeCreateRequest request)
        {
            request.PointTypeOptions = request.PointTypeOptions.Where(x => x.IsCheckd).ToList();

            var pointType = new PointType()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = base.GetOwner(),
                UpdatedAt = null,
                UpdatedBy = null,
                PointTypeOptions = request.PointTypeOptions.Select(x => new PointTypeOption()
                {
                    OptionId = x.OptionId
                }).ToList()
            };

            await _context.AddAsync(pointType);
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Update(int pointTypeId, PointTypeCreateRequest request)
        {
            request.PointTypeOptions = request.PointTypeOptions.Where(x => x.IsCheckd).ToList();

            var pointType = await _context.PointTypes
                .FirstOrDefaultAsync(x => x.Id == pointTypeId);

            if (pointType == null)
            {
                return false;
            }

            var pointTypeOptions = await _context.PointTypeOptions
                .Where(x => x.PointTypeId == pointTypeId)
                .ToListAsync();

            // Xóa những cái không có id trả về
            var pointTypeOptionsDelete = pointTypeOptions.Where(x => !request.PointTypeOptions.Any(lto => lto.OptionId == x.OptionId));
            _context.RemoveRange(pointTypeOptionsDelete);

            // Thêm những cái trả về không có id
            var pointTypeOptionsInsert = request.PointTypeOptions.Where(x => !pointTypeOptions.Any(lto => lto.OptionId == x.OptionId));
            var pointTypeOptionNew = pointTypeOptionsInsert.Select(x => new PointTypeOption()
            {
                PointTypeId = pointTypeId,
                OptionId = x.OptionId
            });

            await _context.AddRangeAsync(pointTypeOptionNew);

            pointType.Name = request.Name;
            pointType.Description = request.Description;
            pointType.UpdatedAt = DateTime.Now;
            pointType.UpdatedBy = base.GetOwner();

            var res = await _context.SaveChangesAsync();

            if (res <= 0)
                return false;

            // Cập nhật tất cả các point 
            // Các point dùng type này
            var points = await _context.Points
                .Include(x => x.PointTypeOptionValues)
                .Where(x => x.PointTypeId == pointTypeId)
                .ToListAsync();

            pointTypeOptionNew = await _context.PointTypeOptions
                .Where(x => x.PointTypeId == pointTypeId)
                .ToListAsync();

            foreach (var item in points)
            {
                // Xóa tất cả các PointTypeOptionValue
                var pointTypeOptionValueDelete = item.PointTypeOptionValues
                    .Where(ltov => pointTypeOptionsDelete.Any(lto => lto.Id == ltov.PointTypeOptionId)).ToList();

                _context.RemoveRange(pointTypeOptionValueDelete);

                // Thêm vào các Point
                var pointTypeOptionValues = pointTypeOptionsInsert.Select(x => new PointTypeOptionValue()
                {
                    PointId = item.Id,
                    PointTypeOptionId = pointTypeOptionNew.FirstOrDefault(lto => lto.OptionId == x.OptionId).Id,
                    ValueN = 0,
                    ValueS = ""
                });

                await _context.AddRangeAsync(pointTypeOptionValues);
            }

            await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Delete(int pointTypeId)
        {
            var pointType = await _context.PointTypes
                .FirstOrDefaultAsync(x => x.Id == pointTypeId);

            _context.Remove(pointType);

            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
