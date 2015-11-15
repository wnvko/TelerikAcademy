namespace DayOfWeek.Host
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Service;

    public class DayOfWeekHost
    {
        public static void Main(string[] args)
        {
            var serviceAddress = new Uri(@"http://localhost:1234/DayOfWeek");
            var selfHost = new ServiceHost(typeof(DayOfWeekService), serviceAddress);

            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);
            (selfHost.Description.Behaviors.FirstOrDefault(b => b is ServiceDebugBehavior) as ServiceDebugBehavior).IncludeExceptionDetailInFaults = true;

            selfHost.Open();
            Console.WriteLine("Service started on {0}", serviceAddress);
            Console.ReadLine();
        }
    }
}
