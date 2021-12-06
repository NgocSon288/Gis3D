using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.PointTypes;
using WebApp.ViewModels.Options;

namespace WebApp.ViewModels.PointTypeOptions
{
    public class PointTypeOptionViewModel
    {
        public int Id { get; set; }

        public int PointTypeId { get; set; }

        public int OptionId { get; set; }

        public PointTypeViewModel PointType { get; set; }

        public OptionViewModel Option { get; set; }
    }
}
