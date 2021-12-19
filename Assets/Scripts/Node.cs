using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
   public string name;
   public int value;
   public List<Connection> connections;

    public Node(string _name, int _value)
    {
        name = _name;
        value = _value;
        connections = new List<Connection>();
    }
}
