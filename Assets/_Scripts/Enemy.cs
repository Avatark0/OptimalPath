using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 currentPos;
    public Vector2 targetPos;

    public PathFinder myPath;

    public float movSpeed;

    void Update()
    {
        if(myPath.path){
            move();
        }        
    }

    private void move(){
        
    }
}
