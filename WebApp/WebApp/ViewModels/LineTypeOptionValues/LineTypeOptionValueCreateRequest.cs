using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.LineTypeOptionValues
{
    public class LineTypeOptionValueCreateRequest
    {
        public int LineTypeOptionId { get; set; }   // Truyền Id ảo

        public string Value { get; set; }           // Đem xuống server rồi convert
    }
}
