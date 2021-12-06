using System.Collections.Generic;
using WebApp.Enums;

namespace WebApp.Entities
{
    public class Point : Metadata
    {
        public int Id { get; set; }
        public int PointTypeId { get; set; }
        public int? BodyId { get; set; } 
        public LOD Lod { get; set; }
        public PointType PointType { get; set; }
        public Node Node { get; set; }
        public Body Body { get; set; }
        public List<PointTypeOptionValue> PointTypeOptionValues { get; set; }
    }
}