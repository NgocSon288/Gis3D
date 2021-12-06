using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.Nodes
{
    public class NodeUpdateRequest
    {
        public int Id { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }
    }
}
