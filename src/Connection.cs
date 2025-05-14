using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    public Node fromNode;
    public Node toNode;
    public float cost;

    public Connection(Node nodeA, Node nodeB, float cost)
    {
        this.fromNode = nodeA;
        this.toNode = nodeB;
        this.cost = cost;
    }
}
