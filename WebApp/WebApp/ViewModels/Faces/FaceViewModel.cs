using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.Bodies;
using WebApp.ViewModels.FaceTypeOptionValues;
using WebApp.ViewModels.FaceTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Faces
{
    public class FaceViewModel
    {
        public int Id { get; set; }

        public int FaceTypeId { get; set; }

        public string Description { get; set; }

        public LOD Lod { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public BodyViewModel Body { get; set; }

        public FaceTypeViewModel FaceType { get; set; }

        public List<NodeViewModel> Nodes { get; set; }

        public List<FaceTypeOptionValueViewModel> FaceTypeOptionValues { get; set; }
    }
}
