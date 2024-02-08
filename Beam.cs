using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NTNU_FirstPlugin
{
    internal class Beam
    {
        public string name;
        public string section;
        public string material;
        public Line axis;
        public Brep geometry;
        public double width;
        public double height;

        public Beam()
        { 
        
        }
        public Beam(string _name)
        {
            name = _name;
        }
        public Beam(string _name, string _section, string _material, Line _axis)
        { 
            name= _name;
            section = _section;
            material = _material;
            axis = _axis;
        }

        public double area(double width , double height)
        {
            double area = 0;
            area = width* height;
 
            return area;
        }

        public Brep createLoftGeometry()
        { 
            Brep brep = new Brep();
            var caxis = axis.ToNurbsCurve();
            var i = caxis.Domain;
            var planes = caxis.GetPerpendicularFrames(new List<double>() { i.Min, i.Max });
            //get me two perp frames at the beign and end 
            Plane plane0 = planes[0];
            Plane plane1 = planes[1];

            //create two rectangles at plane 0 and 1
            Rectangle3d rec1 = new Rectangle3d(plane0, width, height);
            Rectangle3d rec2 = new Rectangle3d(plane1, width, height);

            List<Curve> crvs = new List<Curve>() { rec1.ToNurbsCurve(), rec2.ToNurbsCurve() };

            brep = Brep.CreateFromLoft(crvs, Point3d.Unset, Point3d.Unset, LoftType.Normal, false)[0];

            return brep;
        }

    }
}
