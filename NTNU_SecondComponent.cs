using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using NTNU_FirstPlugin;
namespace NTNU_FirstPlugin
{
    public class NTNU_SecondComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the NTNU_SecondComponent class.
        /// </summary>
        public NTNU_SecondComponent()
          : base("NTNU_SecondComponent", "Nickname",
              "Description",
              "NTNU", "Test")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("number1","n1","first number",GH_ParamAccess.item);
            pManager.AddNumberParameter("number2", "n2", "second number", GH_ParamAccess.item);
            pManager.AddGenericParameter("something","s","something class object",GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("result", "r", "result number", GH_ParamAccess.item);
            pManager.AddGenericParameter("something", "s", " ", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double n1 = 0;
            double n2 = 0;
            ClassSomething something = new ClassSomething();
            DA.GetData(0, ref n1);
            DA.GetData(1, ref n2);
            DA.GetData(2, ref something);
            something.width = n1;
            something.height = n2;

            double r  = NTNU_methods.giveMeSum(n1,n2);
            DA.SetData(0, r);
            DA.SetData(1, something);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
    /*
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }
    */
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5FEFC804-475F-40D0-A9AA-DB076E0F2C10"); }
        }
    }
}