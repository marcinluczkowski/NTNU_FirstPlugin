using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace NTNU_FirstPlugin
{
    public class NTNU_FirstPluginInfo : GH_AssemblyInfo
    {
        public override string Name => "NTNU_FirstPlugin";

        //Return a 24x24 pixel bitmap to represent this GHA library.
      //  public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("57f64b3a-7ab8-4bc8-b131-54db06112ab3");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}