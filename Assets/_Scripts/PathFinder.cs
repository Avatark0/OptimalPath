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
    private int nodeCounter;


    private void Awake() {
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

    private PathNode GetNodeFromPos(Vector2 pos){
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
       
        return grid[x, y];
    }

    public Path FindOptimalPath(Vector2 currentPos, Vector2 targetPos){
        PathNode currentNode = GetNodeFromPos(currentPos);
        PathNode targetNode = GetNodeFromPos(targetPos);

        Path optimalPath = new Path(currentNode, targetNode);
        
        StartCoroutine(CalculatePath(optimalPath));

        return optimalPath;
    }


    public IEnumerator CalculatePath(Path optimalPath){
        // Inicializa a Lista aberta
        GetNeighborNodes(optimalPath.currentNode);

        // Laço para explorar a lista aberta
        while(openList.First != null){
            PathNode currentNode = openList.First.Value;
            openList.RemoveFirst();
            closedList.AddFirst(currentNode);
            optimalPath.pathList.AddFirst(currentNode);

            if(currentNode.Equals(optimalPath.targetNode)){
                Debug.Log("Achei!");
                yield break;
            }

            GetNeighborNodes(currentNode);
        }

        Debug.Log("Não achei...");
        
        yield return null;
    }

    private void GetNeighborNodes(PathNode pos){
        if(pos.x > 0){
            PathNode back = grid[pos.x - 1, pos.y];
            if(back.IsWalkable() && !IsInList(back, closedList) && !IsInList(back, openList)){
                openList.AddFirst(back);

                Debug.Log("back");
                PathVisualizer.SpawnPathSprite(back, nodeCounter++);
            }
        }

        if(pos.y > 0){
            PathNode down = grid[pos.x, pos.y - 1];
            if(down.IsWalkable() && !IsInList(down, closedList) && !IsInList(down, openList)){
                openList.AddFirst(down);

                Debug.Log("down");
                PathVisualizer.SpawnPathSprite(down, nodeCounter++);
            }
        }

        if(pos.y < gridHeight - 1){
            PathNode up = grid[pos.x, pos.y + 1];
            if(up.IsWalkable() && !IsInList(up, closedList) && !IsInList(up, openList)){
                openList.AddFirst(up);

                Debug.Log("up");
                PathVisualizer.SpawnPathSprite(up, nodeCounter++);
            }
        }

        if(pos.x < gridWidth - 1){
            PathNode front = grid[pos.x + 1, pos.y];
            if(front.IsWalkable() && !IsInList(front, closedList) && !IsInList(front, openList)){
                openList.AddFirst(front);

                Debug.Log("front");
                PathVisualizer.SpawnPathSprite(front, nodeCounter++);
            }
        }
    }

    private bool IsInList(PathNode node, LinkedList<PathNode> list){
        foreach(PathNode listNode in list){
            if(node.id == listNode.id){
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
