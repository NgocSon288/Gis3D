using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.PointTypeOptionValues;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Points
{
    public class PointCreateRequest
    {
        public int PointTypeId { get; set; }     // Chọn PointType, sẽ render form tương ứng, truyền xuống server để biết lưu

        public int? BodyId { get; set; }            // Chọn body

        public LOD Lod { get; set; }                // Chọn độ chi tiết

        public string Description { get; set; }     // Mô tả metadata

        public NodeCreateRequest Node { get; set; }

        public List<PointTypeOptionValueCreateRequest> PointTypeOptionValues { get; set; }
    }
}
