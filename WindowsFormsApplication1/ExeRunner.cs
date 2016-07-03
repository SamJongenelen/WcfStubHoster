using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ExeRunner
    {
        string exePath = "notepad.exe";

        public ExeRunner(string stapNaam, string automatorId)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = exePath;
            //exePath
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = stapNaam + " " + automatorId;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }
    }

    public class ExeNotAvailableException : Exception
    {
        public ExeNotAvailableException(string message)
        {

        }
    }
}
