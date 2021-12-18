using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.Enums;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.Faces;
using WebApp.ViewModels.FaceTypeOptionValues;
using WebApp.ViewModels.FaceTypes;
using WebApp.ViewModels.Lines;
using WebApp.ViewModels.LineTypeOptionValues;
using WebApp.ViewModels.LineTypes;
using WebApp.ViewModels.Nodes;
using WebApp.ViewModels.Points;
using WebApp.ViewModels.PointTypeOptionValues;
using WebApp.ViewModels.PointTypes;

namespace WebApp.Services
{
    public class ApiService : BaseService, IApiService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ApiService(ApplicationDbContext context,
            IConfiguration configuration) : base(configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<BodyViewModel>> ApiGetBodiesGis(BodyRequest request)
        {
            try
            {
                // FaceTypeOptions
                var faceTypeOptions = await _context.FaceTypeOptions
                     .Include(x => x.Option)
                     .ToListAsync();
                var faceTypeOptionDictionary = faceTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                // LineTypeOptions
                var lineTypeOptions = await _context.LineTypeOptions
                     .Include(x => x.Option)
                     .ToListAsync();
                var lineTypeOptionDictionary = lineTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                // PointTypeOptions
                var pointTypeOptions = await _context.PointTypeOptions
                     .Include(x => x.Option)
                     .ToListAsync();
                var pointTypeOptionDictionary = pointTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });

                // Tạm thời chỉ lấy body/ sau này sẽ là list dynamic

                // Lấy body có trong bodyId
                var bodies = await _context.Bodies
                    .Include(x => x.Faces)
                        .ThenInclude(x => x.Nodes)
                    .Include(x => x.Faces)
                        .ThenInclude(x => x.FaceTypeOptionValues)
                    .Include(x => x.Faces)
                        .ThenInclude(x => x.FaceType)
                    .Include(x => x.Lines)
                        .ThenInclude(x => x.Nodes)
                    .Include(x => x.Lines)
                        .ThenInclude(x => x.LineTypeOptionValues)
                    .Include(x => x.Lines)
                        .ThenInclude(x => x.LineType)
                    .Include(x => x.Points)
                        .ThenInclude(x => x.Node)
                    .Include(x => x.Points)
                        .ThenInclude(x => x.PointTypeOptionValues)
                    .Include(x => x.Points)
                        .ThenInclude(x => x.PointType)

                    .Where(x => request.BodyId.Contains(x.Id))
                    .ToListAsync();

                var bodiesVm = bodies.Select(x => new BodyViewModel()
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    CreatedBy = x.CreatedBy,
                    Description = x.Description,
                    Faces = x.Faces.Where(f => f.Lod <= request.Lod).Select(f => new FaceViewModel()
                    {
                        Id = f.Id,
                        UpdatedBy = f.UpdatedBy,
                        UpdatedAt = f.UpdatedAt,
                        CreatedAt = f.CreatedAt,
                        CreatedBy = f.CreatedBy,
                        Description = f.Description,
                        Nodes = f.Nodes.Select(n => new NodeViewModel()
                        {
                            Id = n.Id,
                            X = n.X,
                            Y = n.Y,
                            Z = n.Z
                        }).ToList(),
                        FaceTypeOptionValues = f.FaceTypeOptionValues.Select(ftov => new FaceTypeOptionValueViewModel()
                        {
                            Name = faceTypeOptionDictionary[ftov.FaceTypeOptionId].Name,
                            Value = faceTypeOptionDictionary[ftov.FaceTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                        }).ToList(),
                        FaceTypeId = f.FaceTypeId,
                        FaceType = new FaceTypeViewModel()
                        {
                            Id = f.FaceTypeId
                        }
                    }).ToList(),
                    Lines = x.Lines.Where(l => l.Lod <= request.Lod).Select(l => new LineViewModel()
                    {
                        Id = l.Id,
                        UpdatedBy = l.UpdatedBy,
                        UpdatedAt = l.UpdatedAt,
                        CreatedAt = l.CreatedAt,
                        CreatedBy = l.CreatedBy,
                        Description = l.Description,
                        Nodes = l.Nodes.Select(n => new NodeViewModel()
                        {
                            Id = n.Id,
                            X = n.X,
                            Y = n.Y,
                            Z = n.Z
                        }).ToList(),
                        LineTypeOptionValues = l.LineTypeOptionValues.Select(ftov => new LineTypeOptionValueViewModel()
                        {
                            Name = lineTypeOptionDictionary[ftov.LineTypeOptionId].Name,
                            Value = lineTypeOptionDictionary[ftov.LineTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                        }).ToList(),
                        LineTypeId = l.LineTypeId,
                        LineType = new LineTypeViewModel()
                        {
                            Id = l.LineTypeId
                        }
                    }).ToList(),
                    Points = x.Points.Where(p => p.Lod <= request.Lod).Select(p => new PointViewModel()
                    {
                        Id = p.Id,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedAt = p.UpdatedAt,
                        CreatedAt = p.CreatedAt,
                        CreatedBy = p.CreatedBy,
                        Description = p.Description,
                        Node = new NodeViewModel()
                        {
                            Id = p.Node.Id,
                            X = p.Node.X,
                            Y = p.Node.Y,
                            Z = p.Node.Z
                        },
                        PointTypeOptionValues = p.PointTypeOptionValues.Select(ftov => new PointTypeOptionValueViewModel()
                        {
                            Name = pointTypeOptionDictionary[ftov.PointTypeOptionId].Name,
                            Value = pointTypeOptionDictionary[ftov.PointTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                        }).ToList(),
                        PointTypeId = p.PointTypeId,
                        PointType = new PointTypeViewModel()
                        {
                            Id = p.PointTypeId
                        }
                    }).ToList(),
                    Name = null,
                    UpdatedAt = x.UpdatedAt,
                    UpdatedBy = x.UpdatedBy
                }).ToList();

                // Thêm trường hợp nếu chọ không xác định
                if (request.BodyId.Contains(0))
                {
                    // Tìm ra các face, line, point không có body đưa vào không xác đính
                    var faces = await _context.Faces
                        .Include(x => x.FaceTypeOptionValues)
                        .Include(x => x.Nodes)
                        .Include(x => x.FaceType)
                        .Where(x => !x.BodyId.HasValue)
                        .ToListAsync();

                    var lines = await _context.Lines
                        .Include(x => x.LineTypeOptionValues)
                        .Include(x => x.Nodes)
                        .Include(x => x.LineType)
                        .Where(x => !x.BodyId.HasValue)
                        .ToListAsync();

                    var points = await _context.Points
                        .Include(x => x.PointTypeOptionValues)
                        .Include(x => x.Node)
                        .Include(x => x.PointType)
                        .Where(x => !x.BodyId.HasValue)
                        .ToListAsync();

                    bodiesVm.Add(new BodyViewModel()
                    {
                        Id = 0,
                        Faces = faces.Where(f => f.Lod <= request.Lod).Select(f => new FaceViewModel()
                        {
                            Id = f.Id,
                            UpdatedBy = f.UpdatedBy,
                            UpdatedAt = f.UpdatedAt,
                            CreatedAt = f.CreatedAt,
                            CreatedBy = f.CreatedBy,
                            Description = f.Description,
                            Nodes = f.Nodes.Select(n => new NodeViewModel()
                            {
                                Id = n.Id,
                                X = n.X,
                                Y = n.Y,
                                Z = n.Z
                            }).ToList(),
                            FaceTypeOptionValues = f.FaceTypeOptionValues.Select(ftov => new FaceTypeOptionValueViewModel()
                            {
                                Name = faceTypeOptionDictionary[ftov.FaceTypeOptionId].Name,
                                Value = faceTypeOptionDictionary[ftov.FaceTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            FaceTypeId = f.FaceTypeId,
                            FaceType = new FaceTypeViewModel()
                            {
                                Id = f.FaceTypeId
                            }
                        }).ToList(),
                        Lines = lines.Where(l => l.Lod <= request.Lod).Select(l => new LineViewModel()
                        {
                            Id = l.Id,
                            UpdatedBy = l.UpdatedBy,
                            UpdatedAt = l.UpdatedAt,
                            CreatedAt = l.CreatedAt,
                            CreatedBy = l.CreatedBy,
                            Description = l.Description,
                            Nodes = l.Nodes.Select(n => new NodeViewModel()
                            {
                                Id = n.Id,
                                X = n.X,
                                Y = n.Y,
                                Z = n.Z
                            }).ToList(),
                            LineTypeOptionValues = l.LineTypeOptionValues.Select(ftov => new LineTypeOptionValueViewModel()
                            {
                                Name = lineTypeOptionDictionary[ftov.LineTypeOptionId].Name,
                                Value = lineTypeOptionDictionary[ftov.LineTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            LineTypeId = l.LineTypeId,
                            LineType = new LineTypeViewModel()
                            {
                                Id = l.LineTypeId
                            }
                        }).ToList(),
                        Points = points.Where(l => l.Lod <= request.Lod).Select(l => new PointViewModel()
                        {
                            Id = l.Id,
                            UpdatedBy = l.UpdatedBy,
                            UpdatedAt = l.UpdatedAt,
                            CreatedAt = l.CreatedAt,
                            CreatedBy = l.CreatedBy,
                            Description = l.Description,
                            Node = new NodeViewModel()
                            {
                                Id = l.Node.Id,
                                X = l.Node.X,
                                Y = l.Node.Y,
                                Z = l.Node.Z
                            },
                            PointTypeOptionValues = l.PointTypeOptionValues.Select(ftov => new PointTypeOptionValueViewModel()
                            {
                                Name = pointTypeOptionDictionary[ftov.PointTypeOptionId].Name,
                                Value = pointTypeOptionDictionary[ftov.PointTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            PointTypeId = l.PointTypeId,
                            PointType = new PointTypeViewModel()
                            {
                                Id = l.PointTypeId
                            }
                        }).ToList()
                    });
                }

                return bodiesVm;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BodyViewModel>> ApiGetBodiesGis2(BodyRequest request)
        {
            try
            {
                // FaceTypeOptions
                var faceTypeOptions = await _context.FaceTypeOptions
                     .Include(x => x.Option)
                     .ToListAsync();
                var faceTypeOptionDictionary = faceTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                // LineTypeOptions
                var lineTypeOptions = await _context.LineTypeOptions
                     .Include(x => x.Option)
                     .ToListAsync();
                var lineTypeOptionDictionary = lineTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });


                // PointTypeOptions
                var pointTypeOptions = await _context.PointTypeOptions
                     .Include(x => x.Option)
                     .ToListAsync();
                var pointTypeOptionDictionary = pointTypeOptions.ToDictionary(x => x.Id, x => new
                {
                    IsNumber = x.Option.IsNumber,
                    Name = x.Option.Name
                });
                 
                for (int i = 0; i < request.BodyId.Count; i++)
                {
                    Console.WriteLine(request.BodyId[i]);
                }

                List<BodyViewModel> bodies = new List<BodyViewModel>();
                 
                for (int i = 0; i < request.BodyId.Count; i++)
                {
                    var bodyId = request.BodyId[i];
                    // Tìm faces
                    var faces = await _context.Faces
                        .Include(x=>x.Nodes)
                        .Include(x=>x.FaceTypeOptionValues)
                        .Where(x => x.BodyId == bodyId)
                        .ToListAsync();

                    // Tìm Lines
                    var lines = await _context.Lines
                        .Include(x => x.Nodes)
                        .Include(x => x.LineTypeOptionValues)
                        .Where(x => x.BodyId == bodyId)
                        .ToListAsync();

                    // Tìn Point
                    var points = await _context.Points
                        .Include(x => x.Node)
                        .Include(x => x.PointTypeOptionValues)
                        .Where(x => x.BodyId == bodyId)
                        .ToListAsync();

                    bodies.Add(new BodyViewModel()
                    {
                        Id = bodyId,
                        Faces = faces.Select(f=> new FaceViewModel()
                        {
                            Nodes = f.Nodes.Select(n => new NodeViewModel()
                            {
                                Id = n.Id,
                                X = n.X,
                                Y = n.Y,
                                Z = n.Z
                            }).ToList(),
                            FaceTypeOptionValues = f.FaceTypeOptionValues.Select(ftov => new FaceTypeOptionValueViewModel()
                            {
                                Name = faceTypeOptionDictionary[ftov.FaceTypeOptionId].Name,
                                Value = faceTypeOptionDictionary[ftov.FaceTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            FaceTypeId = f.FaceTypeId,
                            FaceType = new FaceTypeViewModel()
                            {
                                Id = f.FaceTypeId
                            }
                        }).ToList(),
                        Lines = lines.Select(l=> new LineViewModel()
                        {
                            Nodes = l.Nodes.Select(n => new NodeViewModel()
                            {
                                Id = n.Id,
                                X = n.X,
                                Y = n.Y,
                                Z = n.Z
                            }).ToList(),
                            LineTypeOptionValues = l.LineTypeOptionValues.Select(ftov => new LineTypeOptionValueViewModel()
                            {
                                Name = lineTypeOptionDictionary[ftov.LineTypeOptionId].Name,
                                Value = lineTypeOptionDictionary[ftov.LineTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            LineTypeId = l.LineTypeId,
                            LineType = new LineTypeViewModel()
                            {
                                Id = l.LineTypeId
                            }
                        }).ToList(),
                        Points = points.Select(p=> new PointViewModel()
                        {
                            Node = new NodeViewModel()
                            {
                                Id = p.Node.Id,
                                X = p.Node.X,
                                Y = p.Node.Y,
                                Z = p.Node.Z
                            },
                            PointTypeOptionValues = p.PointTypeOptionValues.Select(ftov => new PointTypeOptionValueViewModel()
                            {
                                Name = pointTypeOptionDictionary[ftov.PointTypeOptionId].Name,
                                Value = pointTypeOptionDictionary[ftov.PointTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            PointTypeId = p.PointTypeId,
                            PointType = new PointTypeViewModel()
                            {
                                Id = p.PointTypeId
                            }
                        }).ToList()
                    });
                }

                if (request.BodyId.Contains(0))
                {
                    var bodyId = 0;
                    // Tìm faces
                    var faces = await _context.Faces
                        .Include(x => x.Nodes)
                        .Include(x => x.FaceTypeOptionValues)
                        .Where(x => x.BodyId == null)
                        .ToListAsync();

                    // Tìm Lines
                    var lines = await _context.Lines
                        .Include(x => x.Nodes)
                        .Include(x => x.LineTypeOptionValues)
                        .Where(x => x.BodyId == null)
                        .ToListAsync();

                    // Tìn Point
                    var points = await _context.Points
                        .Include(x => x.Node)
                        .Include(x => x.PointTypeOptionValues)
                        .Where(x => x.BodyId == null)
                        .ToListAsync();

                    bodies.Add(new BodyViewModel()
                    {
                        Id = bodyId,
                        Faces = faces.Select(f => new FaceViewModel()
                        {
                            Nodes = f.Nodes.Select(n => new NodeViewModel()
                            {
                                Id = n.Id,
                                X = n.X,
                                Y = n.Y,
                                Z = n.Z
                            }).ToList(),
                            FaceTypeOptionValues = f.FaceTypeOptionValues.Select(ftov => new FaceTypeOptionValueViewModel()
                            {
                                Name = faceTypeOptionDictionary[ftov.FaceTypeOptionId].Name,
                                Value = faceTypeOptionDictionary[ftov.FaceTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            FaceTypeId = f.FaceTypeId,
                            FaceType = new FaceTypeViewModel()
                            {
                                Id = f.FaceTypeId
                            }
                        }).ToList(),
                        Lines = lines.Select(l => new LineViewModel()
                        {
                            Nodes = l.Nodes.Select(n => new NodeViewModel()
                            {
                                Id = n.Id,
                                X = n.X,
                                Y = n.Y,
                                Z = n.Z
                            }).ToList(),
                            LineTypeOptionValues = l.LineTypeOptionValues.Select(ftov => new LineTypeOptionValueViewModel()
                            {
                                Name = lineTypeOptionDictionary[ftov.LineTypeOptionId].Name,
                                Value = lineTypeOptionDictionary[ftov.LineTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            LineTypeId = l.LineTypeId,
                            LineType = new LineTypeViewModel()
                            {
                                Id = l.LineTypeId
                            }
                        }).ToList(),
                        Points = points.Select(p => new PointViewModel()
                        {
                            Node = new NodeViewModel()
                            {
                                Id = p.Node.Id,
                                X = p.Node.X,
                                Y = p.Node.Y,
                                Z = p.Node.Z
                            },
                            PointTypeOptionValues = p.PointTypeOptionValues.Select(ftov => new PointTypeOptionValueViewModel()
                            {
                                Name = pointTypeOptionDictionary[ftov.PointTypeOptionId].Name,
                                Value = pointTypeOptionDictionary[ftov.PointTypeOptionId].IsNumber ? ftov.ValueN : ftov.ValueS
                            }).ToList(),
                            PointTypeId = p.PointTypeId,
                            PointType = new PointTypeViewModel()
                            {
                                Id = p.PointTypeId
                            }
                        }).ToList()
                    });
                }


                return bodies;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<BodyViewModel>> ApiGetBodies()
        {
            var bodies = await _context.Bodies
               .Include(x => x.Faces)
               .ToListAsync();

            bodies.Insert(0, new Entities.Body()
            {
                Id = 0,
                Name = "Không xác định",
                Description = "Không xác định"
            });

            var bodiesVm = bodies.Select(x => new BodyViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return bodiesVm;
        }

        public List<LOD> ApiGetLods()
        {
            return Enum.GetValues(typeof(LOD)).Cast<LOD>().ToList();
        }

    }
}
