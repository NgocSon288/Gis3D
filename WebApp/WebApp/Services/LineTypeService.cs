using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Entities;
using WebApp.ViewModels.LineTypeOptions;
using WebApp.ViewModels.LineTypes;
using WebApp.ViewModels.Options;

namespace WebApp.Services
{
    public class LineTypeService : BaseService, ILineTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LineTypeService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<LineTypeViewModel>> GetAll()
        {
            var lineTypes = await _context.LineTypes.ToListAsync();

            return lineTypes.Select(x => new LineTypeViewModel()
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

        public async Task<LineTypeCreateRequest> GetById(int lineTypeId)
        {
            var lineType = await _context.LineTypes
                .Include(x => x.LineTypeOptions)
                .FirstOrDefaultAsync(x => x.Id == lineTypeId);
            var options = await _context.Options.ToListAsync();

            return new LineTypeCreateRequest()
            {
                Id = lineType.Id,
                Name = lineType.Name,
                Description = lineType.Description,
                CreatedAt = lineType.CreatedAt,
                CreatedBy = lineType.CreatedBy,
                UpdatedAt = lineType.UpdatedAt,
                UpdatedBy = lineType.UpdatedBy,
                LineTypeOptions = options.Select(x => new LineTypeOptionCreateRequest()
                {
                    OptionId = x.Id,
                    IsCheckd = lineType.LineTypeOptions.Any(lto => lto.OptionId == x.Id)
                }).ToList()
            };
        }

        public async Task<LineTypeCreateRequest> GetFirstLineType()
        {
            var lineType = await _context.LineTypes
                .Include(x => x.LineTypeOptions)
                .FirstOrDefaultAsync();
            var options = await _context.Options.ToListAsync();

            return new LineTypeCreateRequest()
            {
                Id = lineType.Id,
                Name = lineType.Name,
                Description = lineType.Description,
                CreatedAt = lineType.CreatedAt,
                CreatedBy = lineType.CreatedBy,
                UpdatedAt = lineType.UpdatedAt,
                UpdatedBy = lineType.UpdatedBy,
                LineTypeOptions = options.Select(x => new LineTypeOptionCreateRequest()
                {
                    OptionId = x.Id,
                    IsCheckd = lineType.LineTypeOptions.Any(lto => lto.OptionId == x.Id)
                }).ToList()
            };
        }

        public async Task<List<LineTypeOptionViewModel>> GetLineTypeOptionByLineTypeId(int lineTypeId)
        {
            var lineTypeOptions = await _context.LineTypeOptions
                .Include(x => x.Option)
                .Where(x => x.LineTypeId == lineTypeId)
                .ToListAsync();

            return lineTypeOptions.Select(x => new LineTypeOptionViewModel()
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

        public async Task<bool> Create(LineTypeCreateRequest request)
        {
            request.LineTypeOptions = request.LineTypeOptions.Where(x => x.IsCheckd).ToList();

            var lineType = new LineType()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = base.GetOwner(),
                UpdatedAt = null,
                UpdatedBy = null,
                LineTypeOptions = request.LineTypeOptions.Select(x => new LineTypeOption()
                {
                    OptionId = x.OptionId
                }).ToList()
            };

            await _context.AddAsync(lineType);
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Update(int lineTypeId, LineTypeCreateRequest request)
        {
            request.LineTypeOptions = request.LineTypeOptions.Where(x => x.IsCheckd).ToList();

            var lineType = await _context.LineTypes
                .FirstOrDefaultAsync(x => x.Id == lineTypeId);

            if (lineType == null)
            {
                return false;
            }

            var lineTypeOptions = await _context.LineTypeOptions
                .Where(x => x.LineTypeId == lineTypeId)
                .ToListAsync();

            // Xóa những cái không có id trả về
            var lineTypeOptionsDelete = lineTypeOptions.Where(x => !request.LineTypeOptions.Any(lto => lto.OptionId == x.OptionId));
            _context.RemoveRange(lineTypeOptionsDelete);

            // Thêm những cái trả về không có id
            var lineTypeOptionsInsert = request.LineTypeOptions.Where(x => !lineTypeOptions.Any(lto => lto.OptionId == x.OptionId));
            var lineTypeOptionNew = lineTypeOptionsInsert.Select(x => new LineTypeOption()
            {
                LineTypeId = lineTypeId,
                OptionId = x.OptionId
            });

            await _context.AddRangeAsync(lineTypeOptionNew);

            lineType.Name = request.Name;
            lineType.Description = request.Description;
            lineType.UpdatedAt = DateTime.Now;
            lineType.UpdatedBy = base.GetOwner();

            var res = await _context.SaveChangesAsync();

            if (res <= 0)
                return false;

            // Cập nhật tất cả các line 
            // Các line dùng type này
            var lines = await _context.Lines
                .Include(x=>x.LineTypeOptionValues)
                .Where(x => x.LineTypeId == lineTypeId)
                .ToListAsync();

            lineTypeOptionNew = await _context.LineTypeOptions
                .Where(x => x.LineTypeId == lineTypeId)
                .ToListAsync(); 

            foreach (var item in lines)
            {
                // Xóa tất cả các LineTypeOptionValue
                var lineTypeOptionValueDelete = item.LineTypeOptionValues
                    .Where(ltov => lineTypeOptionsDelete.Any(lto => lto.Id == ltov.LineTypeOptionId)).ToList();

                _context.RemoveRange(lineTypeOptionValueDelete);

                // Thêm vào các Line
                var lineTypeOptionValues = lineTypeOptionsInsert.Select(x => new LineTypeOptionValue()
                {
                    LineId = item.Id,
                    LineTypeOptionId = lineTypeOptionNew.FirstOrDefault(lto=>lto.OptionId == x.OptionId).Id,
                    ValueN = 0,
                    ValueS = ""
                });

               await  _context.AddRangeAsync(lineTypeOptionValues);
            }

            await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Delete(int lineTypeId)
        {
            var lineType = await _context.LineTypes
                .FirstOrDefaultAsync(x => x.Id == lineTypeId);

            _context.Remove(lineType);

            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
