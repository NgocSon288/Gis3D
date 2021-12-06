using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Entities;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Lines;
using WebApp.ViewModels.LineTypeOptionValues;
using WebApp.ViewModels.LineTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.Services
{
    public class LineService : BaseService, ILineService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LineService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<LineViewModel>> GetAll()
        {
            var lines = await _context.Lines
                .Include(x => x.LineType)
                .Include(x => x.LineTypeOptionValues)
                .Include(x => x.Nodes)
                .Include(x => x.Body)
                .ToListAsync();


            var lineTypeOptions = await _context.LineTypeOptions
            .Include(x => x.Option)
            .ToListAsync();
            var lineTypeOptionDictionary = lineTypeOptions.ToDictionary(x => x.Id, x => new
            {
                IsNumber = x.Option.IsNumber,
                Name = x.Option.Name
            });


            return lines.Select(x => new LineViewModel()
            {
                Id = x.Id,
                LineTypeId = x.LineTypeId,
                LineType = new LineTypeViewModel()
                {
                    Id = x.LineType.Id,
                    Name = x.LineType.Name
                },
                LineTypeOptionValues = x.LineTypeOptionValues.Select(ftov => new LineTypeOptionValueViewModel()
                {
                    Name = lineTypeOptionDictionary[ftov.LineTypeOptionId].Name,
                    Value = lineTypeOptionDictionary[ftov.LineTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
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

        public async Task<LineUpdateRequest> GetById(int lineId)
        {
            try
            {
                Line line = await _context.Lines
                .Include(x => x.LineType)
                .Include(x => x.LineTypeOptionValues)
                .Include(x => x.Nodes)
                .FirstOrDefaultAsync(x => x.Id == lineId);


                var lineTypeOptions = await _context.LineTypeOptions
                .Include(x => x.Option)
                .ToListAsync();
                var lineTypeOptionDictionary = lineTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                return new LineUpdateRequest()
                {
                    Id = line.Id,
                    LineTypeId = line.LineTypeId,
                    LineType = new LineTypeViewModel()
                    {
                        Id = line.LineType.Id,
                        Name = line.LineType.Name
                    },
                    LineTypeOptionValues = line.LineTypeOptionValues.Select(ftov => new LineTypeOptionValueUpdateRequest()
                    {
                        Id = ftov.Id,
                        LineTypeOptionId = ftov.LineTypeOptionId,
                        Name = lineTypeOptionDictionary[ftov.LineTypeOptionId].Name,
                        Value = ftov.ValueS
                    }).ToList(),
                    Nodes = line.Nodes.Select(n => new NodeUpdateRequest()
                    {
                        Id = n.Id,
                        X = n.X,
                        Y = n.Y,
                        Z = n.Z
                    }).ToList(),
                    Lod = line.Lod,
                    Description = line.Description,
                    BodyId = line.BodyId
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Create(LineCreateRequest request)
        {
            try
            {
                var lineTypeOptions = await _context.LineTypeOptions
                .Include(x => x.Option)
                .Where(x => x.LineTypeId == request.LineTypeId)
                .ToListAsync();
                var lineTypeOptionDictionary = lineTypeOptions.ToDictionary(x => x.Id, x => x.Option.IsNumber);

                var line = new Line()
                {
                    LineTypeId = request.LineTypeId,
                    LineTypeOptionValues = request.LineTypeOptionValues.Select(x => new LineTypeOptionValue()
                    {
                        LineTypeOptionId = x.LineTypeOptionId,
                        ValueN = lineTypeOptionDictionary[x.LineTypeOptionId] ? double.Parse(x.Value) : 0,
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

                await _context.AddAsync(line);
                var res = await _context.SaveChangesAsync();

                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(int lineId, LineUpdateRequest request)
        {
            try
            {
                var line = await _context.Lines
                    .Include(x => x.Nodes)
                    .FirstOrDefaultAsync(x => x.Id == lineId);

                if (line == null)
                {
                    return false;
                }

                var optionValueDictionary = await _context.LineTypeOptionValues
                    .Where(x => x.LineId == lineId)
                    .ToDictionaryAsync(x => x.Id, x => x);

                var lineTypeOptionDictionary = await _context.LineTypeOptions
                    .Include(x => x.Option)
                    .ToDictionaryAsync(x => x.Id, x => x.Option.IsNumber);

                // Cập nhật options
                foreach (var item in request.LineTypeOptionValues)
                {
                    var itemUpdate = optionValueDictionary[item.Id];

                    itemUpdate.ValueN = lineTypeOptionDictionary[item.LineTypeOptionId] ? double.Parse(item.Value) : 0;
                    itemUpdate.ValueS = item.Value;
                }

                // Cập nhật các nodes
                // Xóa những node không có id trả vè
                var nodes = line.Nodes;     // Các node hiện có
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
                    LineId = lineId
                }));

                // Cập nhật các thông số cơ bản
                line.BodyId = request.BodyId.HasValue ? (request.BodyId.Value > 0 ? request.BodyId.Value : null) : null;
                line.Lod = request.Lod;
                line.Description = request.Description;

                line.UpdatedBy = base.GetOwner();
                line.UpdatedAt = DateTime.Now;

                var res = await _context.SaveChangesAsync();

                return res > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int lineId)
        {
            try
            {
                var line = await _context.Lines
                .FirstOrDefaultAsync(x => x.Id == lineId);

                if (line == null)
                    return false;

                _context.Remove(line);

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
