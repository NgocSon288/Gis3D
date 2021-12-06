using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.Faces;
using WebApp.ViewModels.Lines;
using WebApp.ViewModels.Points;

namespace WebApp.ViewModels.Bodies
{
    public class BodyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<FaceViewModel> Faces { get; set; }

        public List<LineViewModel> Lines { get; set; }

        public List<PointViewModel> Points { get; set; }
    }
}
