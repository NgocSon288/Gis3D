using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.PointTypeOptionValues
{
    public class PointTypeOptionValueCreateRequest
    {
        public int PointTypeOptionId { get; set; }   // Truyền Id ảo

        public string Value { get; set; }           // Đem xuống server rồi convert
    }
}
