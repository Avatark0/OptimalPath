using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public int x;
    public int y;
    public bool hasWall;

    private void Start(){
        x = Mathf.RoundToInt(transform.position.x);
        y = Mathf.RoundToInt(transform.position.y);

        GameObject[] gameGraph = GameObject.FindGameObjectsWithTag("GameGraph");
        gameGraph[0].GetComponent<PathGraph>().graph.Add(this);
    }
}
