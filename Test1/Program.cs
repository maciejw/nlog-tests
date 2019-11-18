﻿namespace Test1
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            using (SerilogTests serilogTests = new SerilogTests())
            {
                //serilogTests.TestSerilog();
            }
            using (NLogTests nLogTests = new NLogTests())
            {
                //nLogTests.TestNLog();
            }
            using (Log4NetTests nLogTests = new Log4NetTests())
            {
                nLogTests.TestLog4Net();
            }
        }
    }
}
