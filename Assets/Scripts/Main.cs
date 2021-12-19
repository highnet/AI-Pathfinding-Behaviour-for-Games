using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject nodePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Graph g = new Graph();
        /*
        g.Add(new Node("A", 0));
        g.Add(new Node("B", 1));
        g.Add(new Node("C", 2));
        g.Add(new Node("D", 3));
        g.Add(new Node("E", 4));
        g.Add(new Node("F", 5));
        g.Add(new Node("G", 6));

        g.Connect(g.FindNode("A"), g.FindNode("B"), 1.3f);
        g.Connect(g.FindNode("A"), g.FindNode("C"), 1.6f);
        g.Connect(g.FindNode("A"), g.FindNode("D"), 3.3f);
        g.Connect(g.FindNode("B"), g.FindNode("E"), 1.5f);
        g.Connect(g.FindNode("B"), g.FindNode("F"), 1.9f);
        g.Connect(g.FindNode("C"), g.FindNode("D"), 1.3f);
        g.Connect(g.FindNode("F"), g.FindNode("G"), 1.4f);
        */

        g.Add(new Node("A", 0));
        g.Add(new Node("B", 1));
        g.Add(new Node("C", 2));
        g.Add(new Node("D", 3));
        g.Add(new Node("E", 4));
        g.Add(new Node("Z", 5));

        g.Connect(g.FindNode("A"), g.FindNode("B"), 4f);
        g.Connect(g.FindNode("A"), g.FindNode("C"), 2f);

        g.Connect(g.FindNode("B"), g.FindNode("C"), 1f);
        g.Connect(g.FindNode("B"), g.FindNode("D"), 5f);

        g.Connect(g.FindNode("C"), g.FindNode("D"), 8f);
        g.Connect(g.FindNode("C"), g.FindNode("E"), 10f);

        g.Connect(g.FindNode("D"), g.FindNode("E"), 2f);
        g.Connect(g.FindNode("D"), g.FindNode("Z"), 6f);

        g.Connect(g.FindNode("E"), g.FindNode("Z"), 5f);



        Path p = Dijkstra(g, g.FindNode("A"),g.FindNode("Z"));

        foreach(Node n in p.route)
        {
            Debug.Log(n.name);
        }

        Debug.Log(p.previous[g.FindNode("Z")].name);
        Debug.Log(p.previous[g.FindNode("D")].name);
        Debug.Log(p.previous[g.FindNode("B")].name);


        for (int i = 0; i < g.nodes.Count; i++)
        {
            GameObject.Instantiate(nodePrefab, new Vector3(5f * i, 0f, 0f), Quaternion.identity);
        }

    }

    public Path Dijkstra(Graph graph, Node source, Node goal)
    {
        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();
        List<Node> Q = new List<Node>();

        foreach(Node v in graph.nodes)
        {
            dist[v] = float.MaxValue;
            prev[v] = null;
            Q.Add(v);
        }
        dist[source] = 0;

        while (Q.Count > 0)
        {
            Node u = Minimum(Q, dist);
            Q.Remove(u);

            foreach (Connection connection in u.connections)
            {
                Node v = connection.toNode;
                if (Q.Contains(v))
                {
                    float alt = dist[u] + connection.cost;
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                    }
                }
            }
        }
        Path p = new Path();
        p.distances = dist;
        p.previous = prev;
        p.route = GenerateRoute(prev,goal);
        return p;
    }

    private List<Node> GenerateRoute(Dictionary<Node, Node> prev, Node goal)
    {
        List<Node> route = new List<Node>();

        Node searchNode = goal;

        while (searchNode != null)
        {
            route.Add(searchNode);
            searchNode = prev[searchNode];
        }
        route.Reverse();

        return route;
    }

    public Node Minimum(List<Node> q, Dictionary<Node, float> dist)
    {
        int minimumDistanceIndex = 0;
        float minimumDistance = dist[q[minimumDistanceIndex]];

        for(int i = 1; i < q.Count; i++)
        {
            if (dist[q[i]] < minimumDistance)
            {
                minimumDistanceIndex = i;
            }
        }

        return q[minimumDistanceIndex];
    }
}


