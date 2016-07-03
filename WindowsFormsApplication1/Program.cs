using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            ExeRunner er = new ExeRunner("VOORBEREIDENRUN","123456789");
            //var s = new WcfStubHoster();
            //s.Start(ServiceNaam.Coda);

            
            //s.Stop(ServiceNaam.Coda);
        }
    }
}
