using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Alphebetizer
{
    
    static class Program
    {
        // I'll need to hide the console - but I should be able to set that flag in the build configurations.
        [STAThread]
        static void Main(string[] args)
        {
            // I'll include the onenote interoperability in this program 
            // but I'll need to set some form of lookup to prevent errors when it isn't present.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Alphebetizer.Views.Elements.Alphebetizer()); // should generate a copy of the default alphebetizer window <for now>
        }
    }
}
