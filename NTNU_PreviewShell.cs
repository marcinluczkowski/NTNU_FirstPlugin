using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class NTNU_PreviewShell : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the NTNU_PreviewShell class.
        /// </summary>
        public NTNU_PreviewShell()
          : base("NTNU_PreviewShell", "Nickname",
              "Description",
              "NTNU", "Geometry")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("gridshell", "gs","",GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("breps","bs","",GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Gridshell gs = new Gridshell();
            DA.GetData(0, ref gs);
            List<Brep> bs = new List<Brep>();

            foreach (Beam beam in gs.beams)
            {
              
                bs.Add(beam.geometry);
            }

            DA.SetDataList(0, bs);

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
       /* protected override System.Drawing.Bitmap Icon
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
            get { return new Guid("F850E033-E664-411E-8A7F-41C04B01809A"); }
        }
    }
}