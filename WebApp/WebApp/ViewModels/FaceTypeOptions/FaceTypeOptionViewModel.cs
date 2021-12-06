using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.FaceTypes;
using WebApp.ViewModels.Options;

namespace WebApp.ViewModels.FaceTypeOptions
{
    public class FaceTypeOptionViewModel
    {
        public int Id { get; set; }

        public int FaceTypeId { get; set; }

        public int OptionId { get; set; }

        public FaceTypeViewModel FaceType { get; set; }

        public OptionViewModel Option { get; set; }
    }
}
