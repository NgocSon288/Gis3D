using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.LineTypes;
using WebApp.ViewModels.Options;

namespace WebApp.ViewModels.LineTypeOptions
{
    public class LineTypeOptionViewModel
    {
        public int Id { get; set; }

        public int LineTypeId { get; set; }

        public int OptionId { get; set; }

        public LineTypeViewModel LineType { get; set; }

        public OptionViewModel Option { get; set; }
    }
}
