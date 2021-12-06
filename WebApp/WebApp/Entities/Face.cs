using System.Collections.Generic;
using WebApp.Enums;

namespace WebApp.Entities
{
    public class Face : Metadata
    {
        public int Id { get; set; }
        public int FaceTypeId { get; set; }
        public int? BodyId { get; set; }
        public LOD Lod { get; set; }
        public FaceType FaceType { get; set; }
        public List<Node> Nodes { get; set; }
        public Body Body { get; set; }
        public List<FaceTypeOptionValue> FaceTypeOptionValues { get; set; }
    }
}