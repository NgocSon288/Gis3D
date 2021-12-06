using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.LineTypeOptionValues;
using WebApp.ViewModels.LineTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Lines
{
    public class LineUpdateRequest
    {
        public int Id { get; set; }

        public int LineTypeId { get; set; }

        public int? BodyId { get; set; }            // Chọn body

        public LOD Lod { get; set; }                // Chọn độ chi tiết

        public string Description { get; set; }     // Mô tả metadata

        public LineTypeViewModel LineType { get; set; }

        public List<NodeUpdateRequest> Nodes { get; set; }

        public List<LineTypeOptionValueUpdateRequest> LineTypeOptionValues { get; set; }
    }
}
