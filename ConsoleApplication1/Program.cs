using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        private static bool _sStop;

        public static void Main(string[] args)
        {
            Console.CancelKeyPress += ConsoleCancelKeyPress;
            while (!_sStop)
            {
                /* put real logic here */
                Console.WriteLine("Still running at {0}", DateTime.Now);
                Thread.Sleep(1000);
            }
        }

        static void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            //you have 2 options here, leave e.Cancel set to false and just handle any
            //graceful shutdown that you can while in here, or set a flag to notify the other
            //thread at the next check that it's to shut down.  I'll do the 2nd option
            e.Cancel = true;
            _sStop = true;
            Console.WriteLine("CancelKeyPress fired...");
            Thread.Sleep(1000);
        }
    }
}
