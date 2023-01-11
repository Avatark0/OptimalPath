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

    MySolver<PathNode, System.Object> aStarSolver;

    public class MySolver<TPathNode, TUserContext> : SettlersEngine.SpatialAStar<TPathNode, 
	TUserContext> where TPathNode : SettlersEngine.IPathNode<TUserContext>
	{
		public MySolver(TPathNode[,] inGrid): base(inGrid){}
	} 

    private void Awake() {
        if(grid == null){
            grid = new PathNode[gridWidth, gridHeight];
            for(int i = 0; i < gridWidth; i++){
                for(int j = 0; j < gridHeight; j++){
                    grid[i,j] = new PathNode(i, j);
                }
            }
        }

        aStarSolver = new MySolver<PathNode, System.Object>(grid);
    }

    public LinkedList<PathNode> FindOptimalPath(Vector2 currentPos, Vector2 targetPos){
        return aStarSolver.Search(currentPos, targetPos, null);
    }

    private PathNode GetNodeFromPos(Vector2 pos){
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
       
        return grid[x, y];
    }

    public static void AddWallOnGrid(Vector2 pos){
        grid[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y)].IsWall(true);
    }

    public static void RemoveWallOnGrid(Vector2 pos){
        grid[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y)].IsWall(false);
    }

    public static bool IsWalkable(Vector2 pos){
        return grid[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y)].IsWalkable(null);
    }
}
