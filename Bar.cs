using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNU_FirstPlugin
{
    internal class Bar
    {
        public string name;
        public string section;
        public string material;
        public Line axis;


        public Bar(string name, string section, string material, Line axis)
        {
            this.name = name;
            this.section = section;
            this.material = material;
            this.axis = axis;
        }

        public Bar()
        { 
            //empty constructor
        }
    }
}
