using F3.Business.Calendar;
using F3.Business.Service;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace F3Area51.Calendar.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("starting up the service.");
                DoSomething().Wait();
                Console.WriteLine("sleeping");
                Thread.Sleep(System.Convert.ToInt32(ConfigurationManager.AppSettings.Get("Interval")) * 60 * 1000);
            }
        }

        private async static Task DoSomething()
        {
            Console.WriteLine("initiating calender business at {0}", DateTime.UtcNow);
            try
            {
                var x = new CalendarBusiness();
                x.WorkoutBusiness = new SheetService();
                F3.Business.Maps.ModelMaps.InitMaps();

                var done = await x.PublishNew();
                Console.WriteLine("The result of operation: {0}", done);
                Console.WriteLine("finished publish at {0}", DateTime.UtcNow);
            }
            catch (Exception exp)
            {
                Console.WriteLine("{0}: {1}", exp.Message, exp.Source);
            }
        }
    }
}
