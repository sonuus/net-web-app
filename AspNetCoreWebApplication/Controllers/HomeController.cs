using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Amazon;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using System.Threading;


namespace AspNetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {

              //  AWS.Logger.AspNetCore.AWSLogger log = new AWS.Logger.AspNetCore.AWSLogger();



            //var dimension = new Dimension
            //{
            //    Name = "TimeToLoadMyPage",
            //    Value = "Time"
            //};
            //DateTime dateTime1 = DateTime.Now;


                //test();

                //ViewData["Message"] = "CCCCCCCCCCCCCCCCCCC" ; // sb.ToString();;
                //TempData["piValue"] = 3.14;
                //DateTime dateTime2 = DateTime.Now;
                //TimeSpan diff = dateTime1 - dateTime2;

                //List<MetricDatum> data = new List<MetricDatum>();
                //data.Add(new MetricDatum()
                //{
                //    MetricName = "TimeToExecute",
                //    //Timestamp = DateTime.Now,
                //    Unit = StandardUnit.Milliseconds ,
                //    Value = diff.Milliseconds 

                //});





                //using (var cw = new AmazonCloudWatchClient(RegionEndpoint.USEast1))
                //{

                //    PutMetricDataRequest pReq= new PutMetricDataRequest()
                //    {

                //        MetricData = data,
                //        Namespace = "Custom/SlowDownCounter"
                //    };

                //    Task<PutMetricDataResponse> t =  cw.PutMetricDataAsync(pReq);
                //    t.Wait();
                //}

            }
            catch (Exception e)
            {

            }

            return View();

           
        }

        public IActionResult Error()
        {
            ViewData["Message"] = "We've encountered an error :(";
            return View();
        }

        private void test()
        {
            int cpuUsageIncreaseby = 10;
            while (true)
            {
                for (int i = 0; i < 24; i++)
                {
                    //Console.WriteLine("am running ");
                    //DateTime start = DateTime.Now;
                    int cpuUsage = cpuUsageIncreaseby;
                    int time = 60000; // duration for cpu must increase for process...
                    List<Thread> threads = new List<Thread>();
                    for (int j = 0; j < Environment.ProcessorCount; j++)
                    {
                        Thread t = new Thread(new ParameterizedThreadStart(CPUKill));
                        t.Start(cpuUsage);
                        threads.Add(t);
                    }
                    Thread.Sleep(time);
                    foreach (var t in threads)
                    {
                        t.Abort();
                    }

                    //DateTime end = DateTime.Now;
                    //TimeSpan span = end.Subtract(start);
                    //Console.WriteLine("Time Difference (seconds): " + span.Seconds);

                    //Console.WriteLine("10 sec wait... for another.");
                    cpuUsageIncreaseby = cpuUsageIncreaseby + 140000000;
                   // System.Threading.Thread.Sleep(20000);
                }
            }
        }

        static void CPUKill(object info)
        {
            // This receives the value passed into the Thread.Start method.
            int value = (int)info;
            Console.WriteLine(value);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int j = 0; j < 100000000; j++)
            {
                sb.Append(j);
                //System.Threading.Thread.Sleep(10000);
                sb.Append(",");
            }
        }
    }
}
