using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : IIndexedObject
{
    public int x;
    public int y;
    public bool isWall;

    public PathNode(int _x, int _y){
        x = _x;
        y = _y;
        Index = x * 10 + y;
        isWall = false;
    }

    public bool IsWalkable(){
        return !isWall;
    }
}
