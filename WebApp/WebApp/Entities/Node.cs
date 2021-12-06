namespace WebApp.Entities
{
    public class Node
    {
        public int Id { get; set; }
        public int? FaceId { get; set; }
        public int? LineId { get; set; }
        public int? PointId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Face Face { get; set; }
        public Line Line { get; set; }
        public Point Point { get; set; }
    }
}