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

        public bool ShouldWriteToFile { get; set; } = false;
        public string TraceOutputFileName { get; set; } = DateTime.Now.Ticks.ToString();

        // called (in debug-mode) when Debug.Write() is called
        public override void Write(string message)
        {
            if (ShouldWriteToFile)
            {
                WriteToFile(message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
        // called (in debug-mode) when Debug.WriteLine() is called
        public override void WriteLine(string message)
        {
            if (ShouldWriteToFile)
            {
                WriteToFile(message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        private void WriteToFile(string message)
        {
            Console.WriteLine($"Creating a new file ${ TraceOutputFileName }");
            string filePath = TraceOutputFileName;//"file.trace";
            System.IO.File.AppendAllLines(filePath, new string[] { message });
        }
    }
}
