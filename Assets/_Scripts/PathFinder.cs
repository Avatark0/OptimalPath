using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // The screen dimensions
    public int gridWidth;
    public int gridHeight;

    // A representation of the game area's graph
    [SerializeField] private static PathNode[,] grid;

    private bool hitTarget;

    void Start(){
        grid = new PathNode[gridWidth, gridHeight];
        for(int i = 0; i < gridWidth; i++){
            for(int j = 0; j < gridHeight; j++){
                grid[i,j] = new PathNode();
            }
        }
    }

    public Path FindOptimalPath(PathNode currentPos, PathNode targetPos){
        Path optimalPath = new Path();
        
        StartCoroutine(CalculatePath(optimalPath));

        return optimalPath;
    }


    public IEnumerator CalculatePath(Path optimalPath){
        PathNode[] openList;
        PathNode[] closedList;

        if(hitTarget)
            yield break;
        
        yield return null;
    }
}
