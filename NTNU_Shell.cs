﻿using System;
using System.Collections.Generic;
using Eto.Forms;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class NTNU_Shell : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the NTNU_Shell class.
        /// </summary>
        public NTNU_Shell()
          : base("NTNU_Shell", "Nickname",
              "Description",
              "NTNU", "Geometry")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("z1","","height of the surface at first curve",GH_ParamAccess.item); //0
            pManager.AddNumberParameter("z2", "", "height of the surface at second curve", GH_ParamAccess.item); //1
            pManager.AddNumberParameter("z3", "", "height of the surface at third curve", GH_ParamAccess.item); //2
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("Shell","s","surface from 3 curves",GH_ParamAccess.item);
            pManager.AddGenericParameter("Gridshell","gs","gridshell class object", GH_ParamAccess.item);
            pManager.AddPointParameter("nodes","","", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double z1 = 0;
            double z2 = 0;
            double z3 = 0;
            DA.GetData(0, ref z1);
            DA.GetData(1, ref z2);
            DA.GetData(2, ref z3);

            Brep shell = new Brep();
            //this is the place for your code


            Point3d p11 = new Point3d(0,0,0);
            Point3d p12 = new Point3d(10, 0, z1);
            Point3d p13 = new Point3d(20, 0, 0);

            Point3d p21 = new Point3d(0, 10, 0);
            Point3d p22 = new Point3d(10, 10, z2);
            Point3d p23 = new Point3d(20, 10, 0);

            Point3d p31 = new Point3d(0, 20, 0);
            Point3d p32 = new Point3d(10, 20, z3);
            Point3d p33 = new Point3d(20, 20, 0);

            List<Point3d> pts1 = new List<Point3d>() {p11,p12,p13 };
            List<Point3d> pts2 = new List<Point3d>() { p21, p22, p23 };
            List<Point3d> pts3 = new List<Point3d>() { p31, p32, p33 };

            Curve crv1 = Curve.CreateControlPointCurve(pts1, 2);
            Curve crv2 = Curve.CreateControlPointCurve(pts2, 2);
            Curve crv3 = Curve.CreateControlPointCurve(pts3, 2);

            List<Curve> crvs = new List<Curve>() { crv1,crv2,crv3 };

            shell = Brep.CreateFromLoft(crvs, Point3d.Unset, Point3d.Unset, LoftType.Normal, false)[0];

            Gridshell gs = new Gridshell();
            gs.shell = shell;
            gs.name = "our first gridshell";
            //gridshell
            Surface srf = shell.Faces[0];
            Interval i0 = srf.Domain(0);
            Interval i1 = srf.Domain(1);

            double step0 = 1.0 / 10.0;
            double step1 = 1.0 / 10.0;

            List<List<Point3d>> nodes = new List<List<Point3d>>();

            for (int i = 0; i < 10+1; i++)
            {
                List<Point3d> nodesInRow = new List<Point3d>();
                for (int j = 0; j < 10+1; j++)
                {
                    double u = i0.ParameterAt(step0 * i);
                    double v = i1.ParameterAt(step1 * j);
                    Point3d node = srf.PointAt(u, v);
                    nodesInRow.Add(node);
                }
                nodes.Add(nodesInRow);
            }
            List<Beam> beams = new List<Beam>();
            for (int i = 0; i < 10; i++)
            {
                List<Point3d> nodes1 = nodes[i];
                List<Point3d> nodes2 = nodes[i+1];
                for (int j = 0; j < nodes1.Count; j++)
                {
                    Line axis = new Line(nodes1[j], nodes2[j]);
                    Beam beam = new Beam();
                    beam.name = "beam in first direction";
                    beam.section = "IPE100";
                    beam.material = "S355";
                    beam.axis = axis;
                    beams.Add(beam);
                }
            }
            gs.beams = beams;
            //it should be finished with shell
            DA.SetData(0, shell);
            DA.SetData(1, gs);
            DA.SetDataList(2, nodes[2]);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
      /*  protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }*/

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("8A9FAA72-AD29-4775-A112-B187EC792917"); }
        }
    }
}