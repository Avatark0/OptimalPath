using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public LinkedList<PathNode> iterationPath;
    public LinkedList<PathNode> optimalPath;

    public PathNode currentNode;
    public PathNode targetNode;

    public bool reachesTarget;

    public Path(PathNode _currentNode, PathNode _targetNode){
        currentNode = _currentNode;
        targetNode = _targetNode;

        pathList = new LinkedList<PathNode>();
    }
}
