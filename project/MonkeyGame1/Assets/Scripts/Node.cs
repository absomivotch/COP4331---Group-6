using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
        public List<Node> neighbours;
        public int x, y;

        public Node(){
            neighbours = new List<Node>();
        }

        public float DistTo(Node tmp){
            return Vector2.Distance(new Vector2(x,y), new Vector2(tmp.x, tmp.y));
        }
}