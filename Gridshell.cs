using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    internal class Gridshell
    {
        public string name;
        public string type;
        public List<Bar> bars;
        public List<Beam> beams;
        public List<Point3d> supports;
        public Brep shell;

    }
}
