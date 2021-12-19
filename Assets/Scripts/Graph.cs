using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public List<Node> nodes;

    public Graph()
    {
        nodes = new List<Node>();
    }
    public List<Connection> GetConnections(Node fromNode)
    {
        return fromNode.connections;
    }

    public void Add(Node _node)
    {
        nodes.Add(_node);
    }

    public void Remove(Node _node)
    {
        nodes.Remove(_node);
    }

    public void Connect(Node _nodeA, Node _nodeB, float _cost)
    {
        _nodeA.connections.Add(new Connection(_nodeA,_nodeB,_cost));
        _nodeB.connections.Add(new Connection(_nodeB, _nodeA, _cost));
    }

    public void Connect(string _nodeA, string _nodeB, float _cost)
    {
       Node nodeA = FindNode(_nodeA);
       Node nodeB = FindNode(_nodeB);

       nodeA.connections.Add(new Connection(nodeA, nodeB, _cost));
       nodeB.connections.Add(new Connection(nodeB, nodeA, _cost));
    }

    public Node FindNode(string id)
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            Node searchNode = nodes[i];
            if (searchNode.name.Equals(id))
            {
                return searchNode;
            }
        }
        return null;
    }


}
