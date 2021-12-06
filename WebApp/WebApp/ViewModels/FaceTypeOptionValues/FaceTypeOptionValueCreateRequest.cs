using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.FaceTypeOptionValues
{
    public class FaceTypeOptionValueCreateRequest
    {
        public int FaceTypeOptionId { get; set; }   // Truyền Id ảo

        public string Value { get; set; }           // Đem xuống server rồi convert
    }
}
