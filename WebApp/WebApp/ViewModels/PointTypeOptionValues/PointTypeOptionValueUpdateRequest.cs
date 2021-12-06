using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.PointTypeOptionValues
{
    public class PointTypeOptionValueUpdateRequest
    {
        public int Id { get; set; }

        public int PointTypeOptionId { get; set; }   // Truyền Id ảo

        public string Name { get; set; }

        public string Value { get; set; }           // Đem xuống server rồi convert
    }
}
