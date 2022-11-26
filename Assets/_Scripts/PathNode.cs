using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public int x;
    public int y;
    public bool isWall;

    public PathNode(){
        x = 0;
        y = 0;
        isWall = false;
        Debug.Log("PathNode Init");
    }

    // private void Start(){
    //     Debug.Log("PathNode Start");

        // x = Mathf.RoundToInt(transform.position.x);
        // y = Mathf.RoundToInt(transform.position.y);

        // GameObject[] gameGraph = GameObject.FindGameObjectsWithTag("GameGraph");
        // gameGraph[0].GetComponent<PathGraph>().graph.Add(this);
    // }
}
