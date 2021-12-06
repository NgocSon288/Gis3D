using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Entities;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Points;
using WebApp.ViewModels.PointTypeOptionValues;
using WebApp.ViewModels.PointTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.Services
{
    public class PointService : BaseService, IPointService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PointService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<PointViewModel>> GetAll()
        {
            var points = await _context.Points
                .Include(x => x.PointType)
                .Include(x => x.PointTypeOptionValues) 
                .Include(x => x.Body)
                .Include(x => x.Node)
                .ToListAsync();


            var pointTypeOptions = await _context.PointTypeOptions
            .Include(x => x.Option)
            .ToListAsync();
            var pointTypeOptionDictionary = pointTypeOptions.ToDictionary(x => x.Id, x => new
            {
                IsNumber = x.Option.IsNumber,
                Name = x.Option.Name
            });


            return points.Select(x => new PointViewModel()
            {
                Id = x.Id,
                PointTypeId = x.PointTypeId,
                PointType = new PointTypeViewModel()
                {
                    Id = x.PointType.Id,
                    Name = x.PointType.Name
                },
                PointTypeOptionValues = x.PointTypeOptionValues.Select(ftov => new PointTypeOptionValueViewModel()
                {
                    Name = pointTypeOptionDictionary[ftov.PointTypeOptionId].Name,
                    Value = pointTypeOptionDictionary[ftov.PointTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                }).ToList(),
                Node = new NodeViewModel()
                {
                    Id = x.Node.Id,
                    X = x.Node.X,
                    Y = x.Node.Y,
                    Z = x.Node.Z
                },
                Lod = x.Lod,
                Description = x.Description,
                Body = new BodyViewModel()
                {
                    Id = x.BodyId.HasValue ? x.BodyId.Value : 0,
                    Name = x.BodyId.HasValue ? x.Body.Name : "Không xác định"
                },
                CreatedBy = x.CreatedBy,
                CreatedAt = x.CreatedAt,
                UpdatedBy = x.UpdatedBy,
                UpdatedAt = x.UpdatedAt
            }).ToList();
        }

        public async Task<PointUpdateRequest> GetById(int pointId)
        {
            try
            {
                Point point = await _context.Points
                .Include(x => x.PointType)
                .Include(x => x.Node)
                .Include(x => x.PointTypeOptionValues) 
                .FirstOrDefaultAsync(x => x.Id == pointId);


                var pointTypeOptions = await _context.PointTypeOptions
                .Include(x => x.Option)
                .ToListAsync();
                var pointTypeOptionDictionary = pointTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                return new PointUpdateRequest()
                {
                    Id = point.Id,
                    PointTypeId = point.PointTypeId,
                    PointType = new PointTypeViewModel()
                    {
                        Id = point.PointType.Id,
                        Name = point.PointType.Name
                    },
                    PointTypeOptionValues = point.PointTypeOptionValues.Select(ftov => new PointTypeOptionValueUpdateRequest()
                    {
                        Id = ftov.Id,
                        PointTypeOptionId = ftov.PointTypeOptionId,
                        Name = pointTypeOptionDictionary[ftov.PointTypeOptionId].Name,
                        Value = ftov.ValueS
                    }).ToList(),
                    Node =  new NodeUpdateRequest()
                    {
                        Id = point.Node.Id,
                        X = point.Node.X,
                        Y = point.Node.Y,
                        Z = point.Node.Z
                    } ,
                    Lod = point.Lod,
                    Description = point.Description,
                    BodyId = point.BodyId
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Create(PointCreateRequest request)
        {
            try
            {
                var pointTypeOptions = await _context.PointTypeOptions
                .Include(x => x.Option)
                .Where(x => x.PointTypeId == request.PointTypeId)
                .ToListAsync();
                var pointTypeOptionDictionary = pointTypeOptions.ToDictionary(x => x.Id, x => x.Option.IsNumber);

                var point = new Point()
                {
                    PointTypeId = request.PointTypeId,
                    PointTypeOptionValues = request.PointTypeOptionValues.Select(x => new PointTypeOptionValue()
                    {
                        PointTypeOptionId = x.PointTypeOptionId,
                        ValueN = pointTypeOptionDictionary[x.PointTypeOptionId] ? double.Parse(x.Value) : 0,
                        ValueS = x.Value
                    }).ToList(),
                    Node =  new Node()
                    {
                        X = request.Node.X,
                        Y = request.Node.Y,
                        Z = request.Node.Z
                    } ,
                    BodyId = request.BodyId.HasValue ? (request.BodyId.Value > 0 ? request.BodyId.Value : null) : null,
                    Lod = request.Lod,
                    Description = request.Description,
                    CreatedAt = DateTime.Now,
                    CreatedBy = base.GetOwner(),
                    UpdatedAt = null,
                    UpdatedBy = null
                };

                await _context.AddAsync(point);
                var res = await _context.SaveChangesAsync();

                return res > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(int pointId, PointUpdateRequest request)
        {
            try
            {
                var point = await _context.Points 
                    .Include(x=>x.Node)
                    .FirstOrDefaultAsync(x => x.Id == pointId);

                if (point == null)
                {
                    return false;
                }

                var optionValueDictionary = await _context.PointTypeOptionValues
                    .Where(x => x.PointId == pointId)
                    .ToDictionaryAsync(x => x.Id, x => x);

                var pointTypeOptionDictionary = await _context.PointTypeOptions
                    .Include(x => x.Option)
                    .ToDictionaryAsync(x => x.Id, x => x.Option.IsNumber);

                // Cập nhật options
                foreach (var item in request.PointTypeOptionValues)
                {
                    var itemUpdate = optionValueDictionary[item.Id];

                    itemUpdate.ValueN = pointTypeOptionDictionary[item.PointTypeOptionId] ? double.Parse(item.Value) : 0;
                    itemUpdate.ValueS = item.Value;
                }

                // Cập nhật các node
                point.Node.X = request.Node.X;
                point.Node.Y = request.Node.Y;
                point.Node.Z = request.Node.Z;

                // Cập nhật các thông số cơ bản
                point.BodyId = request.BodyId.HasValue ? (request.BodyId.Value > 0 ? request.BodyId.Value : null) : null;
                point.Lod = request.Lod;
                point.Description = request.Description;

                point.UpdatedBy = base.GetOwner();
                point.UpdatedAt = DateTime.Now;

                var res = await _context.SaveChangesAsync();

                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int pointId)
        {
            try
            {
                var point = await _context.Points
                .FirstOrDefaultAsync(x => x.Id == pointId);

                if (point == null)
                    return false;

                _context.Remove(point);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
