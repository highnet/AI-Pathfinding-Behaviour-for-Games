using System.Collections.Generic;

public class Path
{
    public List<Node> route;
    public Dictionary<Node, float> distances;
    public Dictionary<Node, Node> previous;
}