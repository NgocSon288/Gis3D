using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.LineTypeOptionValues;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Lines
{
    public class LineCreateRequest
    {
        public int LineTypeId { get; set; }     // Chọn LineType, sẽ render form tương ứng, truyền xuống server để biết lưu

        public int? BodyId { get; set; }            // Chọn body

        public LOD Lod { get; set; }                // Chọn độ chi tiết

        public string Description { get; set; }     // Mô tả metadata

        public List<NodeCreateRequest> Nodes { get; set; }

        public List<LineTypeOptionValueCreateRequest> LineTypeOptionValues { get; set; }
    }
}
