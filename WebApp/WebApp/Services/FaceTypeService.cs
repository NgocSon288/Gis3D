using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Entities;
using WebApp.ViewModels.FaceTypeOptions;
using WebApp.ViewModels.FaceTypes;
using WebApp.ViewModels.Options;

namespace WebApp.Services
{
    public class FaceTypeService : BaseService, IFaceTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public FaceTypeService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<FaceTypeViewModel>> GetAll()
        {
            var faceTypes = await _context.FaceTypes.ToListAsync();

            return faceTypes.Select(x => new FaceTypeViewModel()
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

        public async Task<FaceTypeCreateRequest> GetById(int faceTypeId)
        {
            var faceType = await _context.FaceTypes
                .Include(x => x.FaceTypeOptions)
                .FirstOrDefaultAsync(x => x.Id == faceTypeId);
            var options = await _context.Options.ToListAsync();

            return new FaceTypeCreateRequest()
            {
                Id = faceType.Id,
                Name = faceType.Name,
                Description = faceType.Description,
                CreatedAt = faceType.CreatedAt,
                CreatedBy = faceType.CreatedBy,
                UpdatedAt = faceType.UpdatedAt,
                UpdatedBy = faceType.UpdatedBy,
                FaceTypeOptions = options.Select(x => new FaceTypeOptionCreateRequest()
                {
                    OptionId = x.Id,
                    IsCheckd = faceType.FaceTypeOptions.Any(lto => lto.OptionId == x.Id)
                }).ToList()
            };
        }

        public async Task<FaceTypeCreateRequest> GetFirstFaceType()
        {
            var faceType = await _context.FaceTypes
                .Include(x => x.FaceTypeOptions)
                .FirstOrDefaultAsync();
            var options = await _context.Options.ToListAsync();

            return new FaceTypeCreateRequest()
            {
                Id = faceType.Id,
                Name = faceType.Name,
                Description = faceType.Description,
                CreatedAt = faceType.CreatedAt,
                CreatedBy = faceType.CreatedBy,
                UpdatedAt = faceType.UpdatedAt,
                UpdatedBy = faceType.UpdatedBy,
                FaceTypeOptions = options.Select(x => new FaceTypeOptionCreateRequest()
                {
                    OptionId = x.Id,
                    IsCheckd = faceType.FaceTypeOptions.Any(lto => lto.OptionId == x.Id)
                }).ToList()
            };
        }

        public async Task<List<FaceTypeOptionViewModel>> GetFaceTypeOptionByFaceTypeId(int faceTypeId)
        {
            var faceTypeOptions = await _context.FaceTypeOptions
                .Include(x => x.Option)
                .Where(x => x.FaceTypeId == faceTypeId)
                .ToListAsync();

            return faceTypeOptions.Select(x => new FaceTypeOptionViewModel()
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

        public async Task<bool> Create(FaceTypeCreateRequest request)
        {
            request.FaceTypeOptions = request.FaceTypeOptions.Where(x => x.IsCheckd).ToList();

            var faceType = new FaceType()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = base.GetOwner(),
                UpdatedAt = null,
                UpdatedBy = null,
                FaceTypeOptions = request.FaceTypeOptions.Select(x => new FaceTypeOption()
                {
                    OptionId = x.OptionId
                }).ToList()
            };

            await _context.AddAsync(faceType);
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Update(int faceTypeId, FaceTypeCreateRequest request)
        {
            request.FaceTypeOptions = request.FaceTypeOptions.Where(x => x.IsCheckd).ToList();

            var faceType = await _context.FaceTypes
                .FirstOrDefaultAsync(x => x.Id == faceTypeId);

            if (faceType == null)
            {
                return false;
            }

            var faceTypeOptions = await _context.FaceTypeOptions
                .Where(x => x.FaceTypeId == faceTypeId)
                .ToListAsync();

            // Xóa những cái không có id trả về
            var faceTypeOptionsDelete = faceTypeOptions.Where(x => !request.FaceTypeOptions.Any(lto => lto.OptionId == x.OptionId));
            _context.RemoveRange(faceTypeOptionsDelete);

            // Thêm những cái trả về không có id
            var faceTypeOptionsInsert = request.FaceTypeOptions.Where(x => !faceTypeOptions.Any(lto => lto.OptionId == x.OptionId));
            var faceTypeOptionNew = faceTypeOptionsInsert.Select(x => new FaceTypeOption()
            {
                FaceTypeId = faceTypeId,
                OptionId = x.OptionId
            });

            await _context.AddRangeAsync(faceTypeOptionNew);

            faceType.Name = request.Name;
            faceType.Description = request.Description;
            faceType.UpdatedAt = DateTime.Now;
            faceType.UpdatedBy = base.GetOwner();

            var res = await _context.SaveChangesAsync();

            if (res <= 0)
                return false;

            // Cập nhật tất cả các face 
            // Các face dùng type này
            var faces = await _context.Faces
                .Include(x => x.FaceTypeOptionValues)
                .Where(x => x.FaceTypeId == faceTypeId)
                .ToListAsync();

            faceTypeOptionNew = await _context.FaceTypeOptions
                .Where(x => x.FaceTypeId == faceTypeId)
                .ToListAsync();

            foreach (var item in faces)
            {
                // Xóa tất cả các FaceTypeOptionValue
                var faceTypeOptionValueDelete = item.FaceTypeOptionValues
                    .Where(ltov => faceTypeOptionsDelete.Any(lto => lto.Id == ltov.FaceTypeOptionId)).ToList();

                _context.RemoveRange(faceTypeOptionValueDelete);

                // Thêm vào các Face
                var faceTypeOptionValues = faceTypeOptionsInsert.Select(x => new FaceTypeOptionValue()
                {
                    FaceId = item.Id,
                    FaceTypeOptionId = faceTypeOptionNew.FirstOrDefault(lto => lto.OptionId == x.OptionId).Id,
                    ValueN = 0,
                    ValueS = ""
                });

                await _context.AddRangeAsync(faceTypeOptionValues);
            }

            await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Delete(int faceTypeId)
        {
            var faceType = await _context.FaceTypes
                .FirstOrDefaultAsync(x => x.Id == faceTypeId);

            _context.Remove(faceType);

            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
