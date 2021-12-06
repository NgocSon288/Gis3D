using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.FaceTypeOptionValues
{
    public class FaceTypeOptionValueUpdateRequest
    {
        public int Id { get; set; }

        public int FaceTypeOptionId { get; set; }   // Truyền Id ảo

        public string Name { get; set; }

        public string Value { get; set; }           // Đem xuống server rồi convert
    }
}
