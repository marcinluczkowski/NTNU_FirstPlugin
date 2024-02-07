using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class DeconstructSomething : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DeconstructSomething class.
        /// </summary>
        public DeconstructSomething()
          : base("DeconstructSomething", "Nickname",
              "Description",
              "NTNU", "Test")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("something", "s","",GH_ParamAccess.item) ;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("name","","",GH_ParamAccess.item);
            pManager.AddNumberParameter("width", "", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("height", "", "", GH_ParamAccess.item);
            pManager.AddTextParameter("material", "", "", GH_ParamAccess.item);
            pManager.AddIntegerParameter("id", "", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ClassSomething s = new ClassSomething();
            DA.GetData(0, ref s);

            string name = s.name;
            double w = s.width;
            double h = s.height;
            string m = s.material;
            int id = s.id;

            DA.SetData(0, name);
            DA.SetData(1, w);
            DA.SetData(2, h);
            DA.SetData(3, m);
            DA.SetData(4, id);


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
            get { return new Guid("63B45BAA-4104-4E9C-8C34-75DDD39DEDB2"); }
        }
    }
}