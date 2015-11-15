namespace StringChecker.Service
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringCheckerService
    {

        [OperationContract]
        int CheckRepeatedCount(string lookIn, string lookFor);
    }
}
