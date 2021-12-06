using System.Collections.Generic;

namespace WebApp.Entities
{
    public class FaceType : Metadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FaceTypeOption> FaceTypeOptions { get; set; }
        public List<Face> Faces { get; set; }
    }
}