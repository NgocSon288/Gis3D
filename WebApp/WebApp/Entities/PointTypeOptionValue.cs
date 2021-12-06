namespace WebApp.Entities
{
    public class PointTypeOptionValue
    {
        public int Id { get; set; }
        public int PointTypeOptionId { get; set; }
        public int PointId { get; set; }
        public double ValueN { get; set; }
        public string ValueS { get; set; }
        public Point Point { get; set; }
    }
}