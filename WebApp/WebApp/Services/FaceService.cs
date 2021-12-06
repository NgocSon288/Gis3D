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
using WebApp.ViewModels.FaceTypeOptionValues;
using WebApp.ViewModels.FaceTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.Services
{
    public class FaceService : BaseService, IFaceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public FaceService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<FaceViewModel>> GetAll()
        {
            var faces = await _context.Faces
                .Include(x => x.FaceType)
                .Include(x => x.FaceTypeOptionValues)
                .Include(x => x.Nodes)
                .Include(x => x.Body)
                .ToListAsync();


            var faceTypeOptions = await _context.FaceTypeOptions
            .Include(x => x.Option)
            .ToListAsync();
            var faceTypeOptionDictionary = faceTypeOptions.ToDictionary(x => x.Id, x => new
            {
                IsNumber = x.Option.IsNumber,
                Name = x.Option.Name
            });


            return faces.Select(x => new FaceViewModel()
            {
                Id = x.Id,
                FaceTypeId = x.FaceTypeId,
                FaceType = new FaceTypeViewModel()
                {
                    Id = x.FaceType.Id,
                    Name = x.FaceType.Name
                },
                FaceTypeOptionValues = x.FaceTypeOptionValues.Select(ftov => new FaceTypeOptionValueViewModel()
                {
                    Name = faceTypeOptionDictionary[ftov.FaceTypeOptionId].Name,
                    Value = faceTypeOptionDictionary[ftov.FaceTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                }).ToList(),
                Nodes = x.Nodes.Select(n => new NodeViewModel()
                {
                    Id = n.Id,
                    X = n.X,
                    Y = n.Y,
                    Z = n.Z
                }).ToList(),
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

        public async Task<FaceUpdateRequest> GetById(int faceId)
        {
            try
            {
                Face face = await _context.Faces
                .Include(x => x.FaceType)
                .Include(x => x.FaceTypeOptionValues)
                .Include(x => x.Nodes)
                .FirstOrDefaultAsync(x => x.Id == faceId);


                var faceTypeOptions = await _context.FaceTypeOptions
                .Include(x => x.Option)
                .ToListAsync();
                var faceTypeOptionDictionary = faceTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                return new FaceUpdateRequest()
                {
                    Id = face.Id,
                    FaceTypeId = face.FaceTypeId,
                    FaceType = new FaceTypeViewModel()
                    {
                        Id = face.FaceType.Id,
                        Name = face.FaceType.Name
                    },
                    FaceTypeOptionValues = face.FaceTypeOptionValues.Select(ftov => new FaceTypeOptionValueUpdateRequest()
                    {
                        Id = ftov.Id,
                        FaceTypeOptionId = ftov.FaceTypeOptionId,
                        Name = faceTypeOptionDictionary[ftov.FaceTypeOptionId].Name,
                        Value = ftov.ValueS
                    }).ToList(),
                    Nodes = face.Nodes.Select(n => new NodeUpdateRequest()
                    {
                        Id = n.Id,
                        X = n.X,
                        Y = n.Y,
                        Z = n.Z
                    }).ToList(),
                    Lod = face.Lod,
                    Description = face.Description,
                    BodyId = face.BodyId
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Create(FaceCreateRequest request)
        {
            try
            {
                var faceTypeOptions = await _context.FaceTypeOptions
                .Include(x => x.Option)
                .Where(x => x.FaceTypeId == request.FaceTypeId)
                .ToListAsync();
                var faceTypeOptionDictionary = faceTypeOptions.ToDictionary(x => x.Id, x => x.Option.IsNumber);

                var face = new Face()
                {
                    FaceTypeId = request.FaceTypeId,
                    FaceTypeOptionValues = request.FaceTypeOptionValues.Select(x => new FaceTypeOptionValue()
                    {
                        FaceTypeOptionId = x.FaceTypeOptionId,
                        ValueN = faceTypeOptionDictionary[x.FaceTypeOptionId] ? double.Parse(x.Value) : 0,
                        ValueS = x.Value
                    }).ToList(),
                    Nodes = request.Nodes.Select(x => new Node()
                    {
                        X = x.X,
                        Y = x.Y,
                        Z = x.Z
                    }).ToList(),
                    BodyId = request.BodyId.HasValue ? (request.BodyId.Value > 0 ? request.BodyId.Value : null) : null,
                    Lod = request.Lod,
                    Description = request.Description,
                    CreatedAt = DateTime.Now,
                    CreatedBy = base.GetOwner(),
                    UpdatedAt = null,
                    UpdatedBy = null
                };

                await _context.AddAsync(face);
                var res = await _context.SaveChangesAsync();

                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(int faceId, FaceUpdateRequest request)
        {
            try
            {
                var face = await _context.Faces
                    .Include(x => x.Nodes)
                    .FirstOrDefaultAsync(x => x.Id == faceId);

                if (face == null)
                {
                    return false;
                }

                var optionValueDictionary = await _context.FaceTypeOptionValues
                    .Where(x => x.FaceId == faceId)
                    .ToDictionaryAsync(x => x.Id, x => x);

                var faceTypeOptionDictionary = await _context.FaceTypeOptions
                    .Include(x => x.Option)
                    .ToDictionaryAsync(x => x.Id, x => x.Option.IsNumber);

                // Cập nhật options
                foreach (var item in request.FaceTypeOptionValues)
                {
                    var itemUpdate = optionValueDictionary[item.Id];

                    itemUpdate.ValueN = faceTypeOptionDictionary[item.FaceTypeOptionId] ? double.Parse(item.Value) : 0;
                    itemUpdate.ValueS = item.Value;
                }

                // Cập nhật các nodes
                // Xóa những node không có id trả vè
                var nodes = face.Nodes;     // Các node hiện có
                var nodeDelete = nodes.Where(x => !request.Nodes.Any(n => n.Id == x.Id)).ToList();
                var nodeUpdate = nodes.Where(x => request.Nodes.Any(n => n.Id == x.Id)).ToList();
                var nodeNew = request.Nodes.Where(x => x.Id <= 0).ToList();

                _context.RemoveRange(nodeDelete);

                // Cập nhật các node có id
                foreach (var item in nodeUpdate)
                {
                    var itemRequest = request.Nodes.FirstOrDefault(x => x.Id == item.Id);

                    item.X = itemRequest.X;
                    item.Y = itemRequest.Y;
                    item.Z = itemRequest.Z;
                }

                // Thêm những node mới không có id
                await _context.AddRangeAsync(nodeNew.Select(x => new Node()
                {
                    X = x.X,
                    Y = x.Y,
                    Z = x.Z,
                    FaceId = faceId
                }));

                // Cập nhật các thông số cơ bản
                face.BodyId = request.BodyId.HasValue ? (request.BodyId.Value > 0 ? request.BodyId.Value : null) : null;
                face.Lod = request.Lod;
                face.Description = request.Description;

                face.UpdatedBy = base.GetOwner();
                face.UpdatedAt = DateTime.Now;

                var res = await _context.SaveChangesAsync();

                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    
        public async Task<bool> Delete(int faceId)
        {
            try
            {
                var face = await _context.Faces
                .FirstOrDefaultAsync(x => x.Id == faceId);

                if (face == null)
                    return false;

                _context.Remove(face);

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
