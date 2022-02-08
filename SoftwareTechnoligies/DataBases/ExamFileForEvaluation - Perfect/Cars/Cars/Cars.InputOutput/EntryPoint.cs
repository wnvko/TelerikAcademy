namespace Cars.Importer
{
    public class EntryPoint
    {
        public static void Main()
        {
            var importer = new Importer("..\\..\\..\\..\\Data.Json.Files");
            importer.Import();

            var searcher = new Searcher("..\\..\\..\\..\\Queries.xml");
            searcher.Search();
        }
    }
}