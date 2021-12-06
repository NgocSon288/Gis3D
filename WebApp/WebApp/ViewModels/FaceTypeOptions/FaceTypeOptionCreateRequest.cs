using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.FaceTypeOptions
{
    public class FaceTypeOptionCreateRequest
    {
        public int OptionId { get; set; }

        public bool IsCheckd { get; set; }
    }
}
