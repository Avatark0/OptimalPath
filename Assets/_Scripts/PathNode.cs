using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : SettlersEngine.IPathNode<System.Object>, SettlersEngine.IIndexedObject
{
    public int x;
    public int y;
    public bool isWall;
    public int Index { get; set; }

    public PathNode(int _x, int _y){
        x = _x;
        y = _y;
        Index = x * 10 + y;
        isWall = false;
    }

    public bool IsWalkable(System.Object unused){
        return !isWall;
    }
}
