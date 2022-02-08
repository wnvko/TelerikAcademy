namespace TSUsingSourceDFS
{
    public class DFSTS
    {
        public static void Main()
        {
            var matrix = new char[,]
                             {
                                {'N','N','N','N','N','N'},
                                {'Y','N','Y','N','N','Y'},
                                {'Y','N','N','N','N','Y'},
                                {'N','N','N','N','N','N'},
                                {'Y','N','Y','N','N','N'},
                                {'Y','N','N','Y','N','N'},
                             };

            var graph = new Graph(matrix);
            graph.TestDfs();
            graph.ShowSort();
        }
    }
}
