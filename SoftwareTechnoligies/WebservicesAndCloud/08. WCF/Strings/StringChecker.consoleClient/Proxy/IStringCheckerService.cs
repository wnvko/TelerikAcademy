namespace StringChecker.Consoleclient.Proxy
{
    using System.CodeDom.Compiler;
    using System.ServiceModel;
    using System.Threading.Tasks;

    [GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [ServiceContractAttribute(ConfigurationName = "IStringCheckerService")]
    public interface IStringCheckerService
    {

        [OperationContract(Action = "http://tempuri.org/IStringCheckerService/CheckRepeatedCount", ReplyAction = "http://tempuri.org/IStringCheckerService/CheckRepeatedCountResponse")]
        int CheckRepeatedCount(string lookIn, string lookFor);

        [OperationContract(Action = "http://tempuri.org/IStringCheckerService/CheckRepeatedCount", ReplyAction = "http://tempuri.org/IStringCheckerService/CheckRepeatedCountResponse")]
        Task<int> CheckRepeatedCountAsync(string lookIn, string lookFor);
    }
}