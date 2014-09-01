using System.Collections.Generic;

public class Node
{
    public string Word;

    public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();

    public bool IsTerminal
    {
        get
        {
            return Word != null;
        }
    }
}
