using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.LineTypeOptionValues;
using WebApp.ViewModels.LineTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Lines
{
    public class LineViewModel
    {
        public int Id { get; set; }

        public int LineTypeId { get; set; }

        public string Description { get; set; }

        public LOD Lod { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public BodyViewModel Body { get; set; }

        public LineTypeViewModel LineType { get; set; }

        public List<NodeViewModel> Nodes { get; set; }

        public List<LineTypeOptionValueViewModel> LineTypeOptionValues { get; set; }
    }
}
