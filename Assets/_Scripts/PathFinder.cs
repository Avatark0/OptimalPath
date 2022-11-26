using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;

    public static PathNode[,] grid;

    void Start(){
        grid = new PathNode[gridWidth, gridHeight];
        for(int i = 0; i < gridWidth; i++){
            for(int j = 0; j < gridHeight; j++){
                grid[i,j] = new PathNode();
            }
        }
        Debug.Log($"grid[0,0].x = {grid[0,0].x}");
    }

    public Path FindOptimalPath(PathNode currentPos, PathNode targetPos){
        PathNode[] openList;
        PathNode[] closedList;
        Path optimalPath = new Path();
        
        return optimalPath;
    }
}
