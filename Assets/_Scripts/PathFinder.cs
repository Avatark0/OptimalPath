using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // The screen dimensions in nodes
    private static int gridWidth = 17;
    private static int gridHeight = 9;
    // A representation of the game area's graph
    [SerializeField] private static PathNode[,] grid;

    // As listas aberta e fechada para explorar o caminho ótimo
    LinkedList<PathNode> openList;
    LinkedList<PathNode> closedList;

    private bool hitTarget;

    public void Awake() {
        if(grid == null){
            grid = new PathNode[gridWidth, gridHeight];
            for(int i = 0; i < gridWidth; i++){
                for(int j = 0; j < gridHeight; j++){
                    grid[i,j] = new PathNode(i, j);
                }
            }
        }

        openList = new LinkedList<PathNode>();
        closedList = new LinkedList<PathNode>();
    }

    public PathNode GetNodeFromPos(Vector2 pos){
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
       
        return grid[x, y];
    }

    public Path FindOptimalPath(PathNode currentPos, PathNode targetPos){
        Path optimalPath = new Path(currentPos, targetPos);
        
        StartCoroutine(CalculatePath(optimalPath));

        Debug.Log($"PathFinder: {optimalPath.pathList.Count}");

        return optimalPath;
    }


    public IEnumerator CalculatePath(Path optimalPath){
        // Inicializa a Lista aberta
        GetNeighborNodes(optimalPath.currentNode);

        // Laço para explorar a lista aberta
        while(openList.First != null){
            optimalPath.pathList.AddFirst(openList.First.Value);

            if(openList.First.Equals(optimalPath.targetNode)){
                yield break;
            }

            GetNeighborNodes(openList.First.Value);

            closedList.AddFirst(openList.First.Value);
            openList.RemoveFirst();
        }
        
        yield return null;
    }

    private void GetNeighborNodes(PathNode pos){
        if(pos.x != 0){
            PathNode back = grid[pos.x - 1, pos.y];
            if(back.IsWalkable() && !IsInClosedList(back)){
                openList.AddFirst(back);
            }
        }

        if(pos.y != 0){
            PathNode down = grid[pos.x, pos.y - 1];
            if(down.IsWalkable() && !IsInClosedList(down)){
                openList.AddFirst(down);
            }
        }

        if(pos.y != gridHeight - 1){
            PathNode up = grid[pos.x, pos.y + 1];
            if(up.IsWalkable() && !IsInClosedList(up)){
                openList.AddFirst(up);
            }
        }

        if(pos.x != gridWidth -1){
            PathNode front = grid[pos.x + 1, pos.y];
            if(front.IsWalkable() && !IsInClosedList(front)){
                openList.AddFirst(front);
            }
        }
    }

    private bool IsInClosedList(PathNode node){
        foreach(PathNode visitedNode in closedList){
            if(node.id == visitedNode.id){
                return true;
            }
        }
        return false;
    }

    private float Heuristic(PathNode node, PathNode targetNode){
        Vector2 startPos = new Vector2(node.x, node.y);
        Vector2 targetPos = new Vector2(targetNode.x, targetNode.y);

        return Vector2.Distance(startPos, targetPos);
    }
}
