namespace AdvancedOOP
{
    public class Edge<T>
    {
        public Edge(Node<T> target, double distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        public Node<T> Target { get; private set; }

        public double Distance { get; private set; }
    }
}
