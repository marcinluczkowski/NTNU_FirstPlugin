using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class DecBeam : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DecBeam class.
        /// </summary>
        public DecBeam()
          : base("DecBeam", "Nickname",
              "Description",
              "NTNU", "Deconstructors")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("beam", "be", "take the beam class object", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("name", "n", "name of the beam", GH_ParamAccess.item); //0
            pManager.AddTextParameter("section", "s", " section of the beam", GH_ParamAccess.item); //1
            pManager.AddTextParameter("material", "m", "material of the beam", GH_ParamAccess.item); //2
            pManager.AddLineParameter("axis", "a", "line for axis", GH_ParamAccess.item); //3
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Beam beam = new Beam();
            DA.GetData(0, ref beam);

            DA.SetData(0, beam.name);
            DA.SetData(1, beam.section);
            DA.SetData(2, beam.material);
            DA.SetData(3, beam.axis);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
     /*   protected override System.Drawing.Bitmap Icon
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
            get { return new Guid("55C8E754-4280-4DC6-9465-3977F96F8D38"); }
        }
    }
}