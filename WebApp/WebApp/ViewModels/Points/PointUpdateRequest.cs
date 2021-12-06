using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.PointTypeOptionValues;
using WebApp.ViewModels.PointTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Points
{
    public class PointUpdateRequest
    {
        public int Id { get; set; }

        public int PointTypeId { get; set; }

        public int? BodyId { get; set; }            // Chọn body

        public LOD Lod { get; set; }                // Chọn độ chi tiết

        public string Description { get; set; }     // Mô tả metadata

        public PointTypeViewModel PointType { get; set; }

        public NodeUpdateRequest Node { get; set; }

        public List<PointTypeOptionValueUpdateRequest> PointTypeOptionValues { get; set; }
    }
}
