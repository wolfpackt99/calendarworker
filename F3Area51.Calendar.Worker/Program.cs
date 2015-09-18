using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using F3.Business.Calendar;
using Google.Apis.Calendar.v3.Data;

namespace F3Area51.Calendar.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("starting up.");
                DoSomething().Wait();
                Console.WriteLine("sleeping");
                Thread.Sleep(10 * 60 * 1000);
            }
        }

        private async static Task DoSomething()
        {
            Console.WriteLine("initiating calender business at {0}", DateTime.UtcNow);
            try
            {
                var x = new CalendarBusiness();

                var done = await x.Publish();
                Console.WriteLine("The result of operation: {0}", done);
                Console.WriteLine("finished publish at {0}", DateTime.UtcNow);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
