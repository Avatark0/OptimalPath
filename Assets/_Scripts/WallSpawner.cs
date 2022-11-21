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

        Debug.Log($"mPos x = {Input.mousePosition.x}, y = {Input.mousePosition.y}");

        Debug.Log($"cPos x = {Camera.main.ScreenToWorldPoint(pos).x}, y = {Camera.main.ScreenToWorldPoint(pos).y}");

        Debug.Log($"cPos x = {x}, y = {y}");

        return new Vector3(x, y, 0);
    }
}
