using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoCortexApiSample
{
    public class MyTraceListener : TraceListener
    {

        public bool ShouldWriteToFile { get; set; } = true;
        public string TraceOutputFileName { get; set; } = DateTime.Now.Ticks.ToString();

        // called (in debug-mode) when Debug.Write() is called
        public override void Write(string message)
        {
            Console.WriteLine(message);
            WriteToFile(message);
        }
        // called (in debug-mode) when Debug.WriteLine() is called
        public override void WriteLine(string message)
        {
            Console.WriteLine(message);
            WriteToFile(message);
        }

        private void WriteToFile(string message)
        {
            string filePath = TraceOutputFileName;
            System.IO.File.AppendAllLines(filePath, new string[] { message });
        }
    }
}
