using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wall;
    public delegate void AddWallAction();
    public static event AddWallAction AddWall;
    public delegate void RemoveWallAction();
    public static event RemoveWallAction RemoveWall;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 pos = spawnPos();
            if(PathFinder.IsWalkable(pos)){
                Instantiate(wall, pos, Quaternion.identity, transform);
                PathFinder.AddWall(pos);
                if(AddWall != null){
                   AddWall();
                }
            }
            else {
                PathFinder.RemoveWall(pos);
                if(RemoveWall != null){
                   RemoveWall();
                }
                // Destruir objeto parede no local!
                Debug.Log($"Destruir parede em {pos}");
            }
        }
    }

    private Vector3 spawnPos(){
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        
        return new Vector3(x, y, 0);
    }
}
