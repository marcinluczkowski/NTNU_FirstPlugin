using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class DecBar : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DecBar class.
        /// </summary>
        public DecBar()
          : base("DecBar", "Nickname",
              "Description",
              "NTNU", "Deconstructors")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("bar","br","take the bar class object",GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("name","n","name of the bar",GH_ParamAccess.item); //0
            pManager.AddTextParameter("section", "s", " section of the bar", GH_ParamAccess.item); //1
            pManager.AddTextParameter("material", "m", "material of the bar", GH_ParamAccess.item); //2
            pManager.AddLineParameter("axis", "a", "line for axis", GH_ParamAccess.item); //3
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Bar bar = new Bar();
            DA.GetData(0, ref bar);

            DA.SetData(0, bar.name);
            DA.SetData(1, bar.section);
            DA.SetData(2, bar.material);
            DA.SetData(3, bar.axis);
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
            get { return new Guid("504BC3A5-79DC-4A49-BA67-BD42CB376B9A"); }
        }
    }
}