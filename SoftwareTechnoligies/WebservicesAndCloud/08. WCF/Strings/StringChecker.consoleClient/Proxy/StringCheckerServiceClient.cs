namespace StringChecker.Consoleclient.Proxy
{
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    [DebuggerStepThrough()]
    [GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StringCheckerServiceClient : ClientBase<IStringCheckerService>, IStringCheckerService
    {

        public StringCheckerServiceClient()
        {
        }

        public StringCheckerServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public StringCheckerServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public StringCheckerServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public StringCheckerServiceClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public int CheckRepeatedCount(string lookIn, string lookFor)
        {
            return base.Channel.CheckRepeatedCount(lookIn, lookFor);
        }

        public System.Threading.Tasks.Task<int> CheckRepeatedCountAsync(string lookIn, string lookFor)
        {
            return base.Channel.CheckRepeatedCountAsync(lookIn, lookFor);
        }
    }
}