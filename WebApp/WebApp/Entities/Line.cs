using System.Collections.Generic;
using WebApp.Enums;

namespace WebApp.Entities
{
    public class Line : Metadata
    {
        public int Id { get; set; }
        public int LineTypeId { get; set; }
        public int? BodyId { get; set; }
        public LOD Lod { get; set; }
        public LineType LineType { get; set; }
        public List<Node> Nodes { get; set; }
        public Body Body { get; set; }
        public List<LineTypeOptionValue> LineTypeOptionValues { get; set; }
    }
}