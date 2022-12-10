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

    // Dicionario de nodes vizinhos
    NeighborNodes neighborNodes;

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

        neighborNodes = new NeighborNodes();
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
        // Inicializa a Lista aberta a partir do nó atual
        IterateNeighborNodes(optimalPath.currentNode);

        // Laço para explorar a lista aberta
        while(openList.First != null){
            PathNode nextNode = openList.First.Value;
            openList.RemoveFirst();
            closedList.AddFirst(nextNode);

            optimalPath.iterationPath.AddFirst(nextNode);

            if(nextNode.Equals(optimalPath.targetNode)){
                Debug.Log("Achei!");
                yield break;
            }

            IterateNeighborNodes(nextNode);
        }

        Debug.Log("Não achei...");
        
        yield return null;
    }

    private void IterateNeighborNodes(PathNode pos){
        neighborNodes.ResetDictionary(); // Guarantees that unset values ​​will be null
        if(pos.x > 0){
            neighborNodes.dictionary["back"] = grid[pos.x - 1, pos.y];
        }
        if(pos.y > 0){
            neighborNodes.dictionary["down"] = grid[pos.x, pos.y - 1];
        }
        if(pos.y < gridHeight - 1){
            neighborNodes.dictionary["up"] = grid[pos.x, pos.y + 1];
        }
        if(pos.x < gridWidth - 1){
            neighborNodes.dictionary["front"] = grid[pos.x + 1, pos.y];
        }
        foreach(KeyValuePair<string, PathNode> node in neighborNodes.dictionary){
            if(node.Value != null && node.Value.IsWalkable()){
                if(!InList(node.Value, closedList) && !InList(node.Value, openList)){
                    aStar(node.Value);
                }
            }
        }
    }

    private void aStar(PathNode node){
        PriorityQueue
        openList.AddFirst(node);
        PathVisualizer.SpawnPathSprite(node, nodeCounter++);
    }

    private bool InList(PathNode node, LinkedList<PathNode> list){
        foreach(PathNode listNode in list){
            if(node.Index == listNode.Index){
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
