namespace DayOfWeek.Service
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekService
    {

        [OperationContract]
        string GetDateDayOfWeek(DateTime date);
    }
}
