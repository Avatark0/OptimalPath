using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Vector2 currentPos;
    public Vector2 targetPos;

    public PathNode[,] grid;

    public bool path;
}
