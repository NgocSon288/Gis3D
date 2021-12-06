namespace WebApp.Entities
{
    public class FaceTypeOptionValue
    {
        public int Id { get; set; }
        public int FaceTypeOptionId { get; set; }               // Tham chiếu giả
        public int FaceId { get; set; }
        public double ValueN { get; set; }                       // Lưu giá trị của option đó
        public string ValueS { get; set; }                       // Lưu giá trị của option đó
        public Face Face { get; set; }
    }
}