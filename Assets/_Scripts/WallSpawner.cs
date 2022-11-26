using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wall;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Instantiate(wall, spawnPos(), Quaternion.identity, transform);
        }
    }

    private Vector3 spawnPos(){
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);
        
        return new Vector3(x, y, 0);
    }
}
