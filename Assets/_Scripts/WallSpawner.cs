using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wall;
    public delegate void ToggleWallAction();
    public static event ToggleWallAction ToggleWallEvent;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 pos = mousePos();
            Debug.Log($"WallSpawner: wall pos = {pos}");
            if(PathFinder.IsWalkable(pos)){
                SinalizeWallToggleEvent();
                PathFinder.AddWallOnGrid(pos);
                Instantiate(wall, pos, Quaternion.identity, transform);
            }
            else {
                SinalizeWallToggleEvent();
                PathFinder.RemoveWallOnGrid(pos);
                foreach(GameObject wall in GameObject.FindGameObjectsWithTag("Wall")){
                    if(wall.transform.position == pos){
                        Destroy(wall);
                    }
                } 
            }
        }
    }

    private void SinalizeWallToggleEvent(){
        if(ToggleWallEvent != null){
            ToggleWallEvent();
        }
    }

    private Vector3 mousePos(){
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        
        return new Vector3(x, y, 0);
    }
}
