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
                DoSomething();
                Thread.Sleep(60 * 1000);
            }
        }

        private static void DoSomething()
        {
            var x = new CalendarBusiness();
            var result = x.Publish();
        }
    }
}
