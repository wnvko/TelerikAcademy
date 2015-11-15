namespace StringChecker.Service
{
    public class StringCheckerService : IStringCheckerService
    {
        public int CheckRepeatedCount(string lookIn, string lookFor)
        {
            int count = 0;
            int startIndex = 0;

            do
            {
                startIndex = lookIn.IndexOf(lookFor, startIndex);
                if (startIndex >= 0)
                {
                    count++;
                    startIndex += lookFor.Length;
                }
            } while (startIndex > 0);

            return count;
        }
    }
}
