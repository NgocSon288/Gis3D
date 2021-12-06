using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.PointTypeOptionValues;
using WebApp.ViewModels.PointTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Points
{
    public class PointViewModel
    {
        public int Id { get; set; }

        public int PointTypeId { get; set; }

        public string Description { get; set; }

        public LOD Lod { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public BodyViewModel Body { get; set; }

        public PointTypeViewModel PointType { get; set; }

        public NodeViewModel Node { get; set; }

        public List<PointTypeOptionValueViewModel> PointTypeOptionValues { get; set; }
    }
}
