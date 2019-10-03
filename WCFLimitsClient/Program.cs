using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFLimitsClient.TestService;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFLimitsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            double syncUnthrottled = 0;
            double syncThrottled = 0;
            double asyncUnthrottled = 0;
            double asyncThrottled = 0;

            int calls = 0;
            int callLimit = 30;

            Console.WriteLine($"Synchronous Unthrottled {callLimit} calls");
            Console.WriteLine();
            using (TestService.TestServiceClient service = new TestService.TestServiceClient())
            {
                Stopwatch watch = Stopwatch.StartNew();
                List<Task> tasks = new List<Task>();

                while (calls < callLimit)
                {
                    Guid guid = Guid.NewGuid();
                    Console.WriteLine($"Time: {DateTime.Now:o} Starting TaskID: {guid}");

                    Responder responder = new Responder(service, guid);

                    Task x = Task.Run(responder.DoItSync);
                    tasks.Add(x);
                    calls++;

                    if (calls == callLimit)
                    {
                        Console.WriteLine($"Call Limit of {callLimit} reached");
                    }
                }
                Console.WriteLine($"Waiting for final calls to end...");

                Task.WhenAll(tasks).ConfigureAwait(false).GetAwaiter().GetResult();
                syncUnthrottled = watch.Elapsed.TotalSeconds;
                Console.WriteLine($"Sync Unthrottled Tasks took {syncUnthrottled} seconds to complete");

            }

            calls = 0;
            Console.WriteLine();
            Console.WriteLine($"Synchronous and throttled 1 instance/channel {callLimit} calls");
            Console.WriteLine();

            using (TestThrottledService.ThrottledTestServiceClient service = new TestThrottledService.ThrottledTestServiceClient())
            {
                List<Task> tasks = new List<Task>();

                Stopwatch watch = Stopwatch.StartNew();

                while (calls < callLimit)
                {
                    Guid guid = Guid.NewGuid();
                    Console.WriteLine($"Time: {DateTime.Now:o} Starting TaskID: {guid}");

                    ResponderThrottled responder = new ResponderThrottled(service, guid);

                    Task x = Task.Run(responder.DoItSync);
                    tasks.Add(x);
                    calls++;

                    if (calls == callLimit)
                    {
                        Console.WriteLine($"Call Limit of {callLimit} reached");
                    }
                }

                Task.WhenAll(tasks).ConfigureAwait(false).GetAwaiter().GetResult();
                syncThrottled = watch.Elapsed.TotalSeconds;
                Console.WriteLine($"Sync Throttled Tasks took {syncThrottled} seconds to complete");
            }

            calls = 0;
            Console.WriteLine();
            Console.WriteLine($"Asynchronous {callLimit} calls");
            Console.WriteLine();
            using (TestService.TestServiceClient service = new TestService.TestServiceClient())
            {
                List<Task> tasks = new List<Task>();

                Stopwatch watch = Stopwatch.StartNew();

                while (calls < callLimit)
                {
                    Guid guid = Guid.NewGuid();
                    Console.WriteLine($"Time: {DateTime.Now:o} Starting TaskID: {guid}");

                    Responder responder = new Responder(service, guid);

                    Task x = Task.Run(responder.DoItAsync);
                    tasks.Add(x);
                    calls++;

                    if (calls == callLimit)
                    {
                        Console.WriteLine($"Call Limit of {callLimit} reached");
                    }
                }

                Task.WhenAll(tasks).ConfigureAwait(false).GetAwaiter().GetResult();

                asyncUnthrottled = watch.Elapsed.TotalSeconds;
                Console.WriteLine($"Async Unthrottled Tasks took {asyncUnthrottled} seconds to complete");
            }

            calls = 0;
            Console.WriteLine();
            Console.WriteLine($"Asynchronous and throttled 1 instance/channel {callLimit} calls");
            Console.WriteLine();

            using (TestThrottledService.ThrottledTestServiceClient service = new TestThrottledService.ThrottledTestServiceClient())
            {
                List<Task> tasks = new List<Task>();

                Stopwatch watch = Stopwatch.StartNew();

                while (calls < callLimit)
                {
                    Guid guid = Guid.NewGuid();
                    Console.WriteLine($"Time: {DateTime.Now:o} Starting TaskID: {guid}");

                    ResponderThrottled responder = new ResponderThrottled(service, guid);

                    Task x = Task.Run(responder.DoItAsync);
                    tasks.Add(x);
                    calls++;

                    if (calls == callLimit)
                    {
                        Console.WriteLine($"Call Limit of {callLimit} reached");
                    }
                }

                Task.WhenAll(tasks).ConfigureAwait(false).GetAwaiter().GetResult();
                asyncThrottled = watch.Elapsed.TotalSeconds;
                Console.WriteLine($"Async Throttled Tasks took {asyncThrottled} seconds to complete");
            }

            Console.WriteLine();
            Console.WriteLine($"Totals are:");
            Console.WriteLine($"Sync Unthrottled  | {syncUnthrottled} seconds to complete");
            Console.WriteLine($"Sync Throttled    | {syncThrottled} seconds to complete");
            Console.WriteLine($"Async Unthrottled | {asyncUnthrottled} seconds to complete");
            Console.WriteLine($"Async Throttled   | {asyncThrottled} seconds to complete");

            Console.ReadLine();
        }
    }

    public class Responder
    {
        TestService.ITestService _testService { get; set; }
        Guid _guid { get; set; }

        public Responder(TestService.ITestService service, Guid guid)
        {
            _testService = service;
            _guid = guid;
        }


        public void DoItSync()
        {
            string returnString = _testService.TestThrottle(_guid.ToString());
            Console.WriteLine(returnString);
        }

        public void DoItAsync()
        {
            string returnString = _testService.TestThrottleAsync(_guid.ToString()).ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(returnString);
        }
    }


    public class ResponderThrottled
    {
        TestThrottledService.IThrottledTestService _testService { get; set; }
        Guid _guid { get; set; }

        public ResponderThrottled(TestThrottledService.IThrottledTestService service, Guid guid)
        {
            _testService = service;
            _guid = guid;
        }

        public void DoItSync()
        {
            string returnString = _testService.TestThrottle(_guid.ToString());
            Console.WriteLine(returnString);
        }

        public void DoItAsync()
        {
            string returnString = _testService.TestThrottleAsync(_guid.ToString()).ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine(returnString);
        }
    }

}
