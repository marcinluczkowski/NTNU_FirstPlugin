using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class NTNU_modfiy_shell : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the NTNU_modfiy_shell class.
        /// </summary>
        public NTNU_modfiy_shell()
          : base("NTNU_modfiy_shell", "Nickname",
              "Description",
              "NTNU", "Modify")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("gridshell","gs","",GH_ParamAccess.item);//gridshell class
            pManager.AddTextParameter("secs", "scs","",GH_ParamAccess.list) ; //list of sections
            //list of 100X200, 200x300, 545x260 ...
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("gridshell", "gs","",GH_ParamAccess.item) ;//gridshell
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Gridshell gs = new Gridshell();
            List<string> secs = new List<string>();
            DA.GetData(0, ref gs);
            DA.GetDataList(1, secs);
            //create the code to update sections from input 1

            int nbeams = gs.beams.Count;
            int nsecs = secs.Count;

            if (nbeams > nsecs)
            {
                //change the sections to have enough data to be fill in the loop below

                int i = 0;
                foreach (Beam b in gs.beams)
                {
                    string sectionName = "";
                    if (i >= nsecs)
                    {
                        sectionName = secs[secs.Count-1];
                    }
                    else 
                    { 
                        sectionName = secs[i];
                    }
                    b.section = sectionName;
                    string[] sectionParams = sectionName.Split('X');
                    b.width = Convert.ToDouble(sectionParams[0]) / 1000;
                    b.height = Convert.ToDouble(sectionParams[1]) / 1000;
                    b.geometry = b.createLoftGeometry();
                    i++;
                }
            }
            else
            {
                int i = 0;
                foreach (Beam b in gs.beams)
                {
                    string sectionName = secs[i];
                    b.section = sectionName;
                    string[] sectionParams = sectionName.Split('X');
                    b.width = Convert.ToDouble(sectionParams[0]) / 1000;
                    b.height = Convert.ToDouble(sectionParams[1]) / 1000;
                    b.geometry = b.createLoftGeometry();
                    i++;
                }
            }
            

            

            DA.SetData(0, gs);
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
            get { return new Guid("9EEB53A3-4701-4466-8C25-EB00B42FD9C3"); }
        }
    }
}