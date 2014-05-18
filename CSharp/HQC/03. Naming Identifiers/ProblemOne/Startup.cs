namespace ProblemOne
{
    public static class Startup
    {
        public static void Main()
        {
            SomeClass.SomeInternalClass instantiation = new SomeClass.SomeInternalClass();
            instantiation.PrintBooleanValue(true);
        }
    }
}