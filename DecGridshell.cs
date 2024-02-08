using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NTNU_FirstPlugin
{
    public class DecGridshell : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the DecGridshell class.
        /// </summary>
        public DecGridshell()
          : base("DecGridshell", "Nickname",
              "Description",
              "NTNU", "Deconstructors")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("gridshell", "gs", "take the gridshell class object", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("name", "n", "name of the gridshell", GH_ParamAccess.item); //0
            pManager.AddTextParameter("type", "t", " type of the gridshell", GH_ParamAccess.item); //1
            pManager.AddGenericParameter("bars", "bs", "list of bar class objects", GH_ParamAccess.list);
            pManager.AddGenericParameter("beams", "bms", "list of beam class objects", GH_ParamAccess.list);
            pManager.AddPointParameter("supports", "ss", "list of points which are the supports", GH_ParamAccess.list);
            pManager.AddBrepParameter("shell","","brep shell under gridshell",GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Gridshell gridshell = new Gridshell();
            DA.GetData(0, ref gridshell);

            DA.SetData(0, gridshell.name);
            DA.SetData(1, gridshell.type);
            DA.SetDataList(2, gridshell.bars);
            DA.SetDataList(3, gridshell.beams);
            DA.SetDataList(4, gridshell.supports);
            DA.SetData(5, gridshell.shell);
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
            get { return new Guid("060B3B4F-D509-4A4A-AD4E-352E295CB363"); }
        }
    }
}