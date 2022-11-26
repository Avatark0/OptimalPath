using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public PathNode currentPos;
    public PathNode targetPos;

    public PathFinder pathFinder;

    public float movSpeed;

    void Start(){
        if(pathFinder == null)
            pathFinder = GameObject.FindGameObjectsWithTag("PathFinder")[0].GetComponent<PathFinder>();
    }

    void Update()
    {
        Path myPath = pathFinder.FindOptimalPath(currentPos, targetPos);
        if(myPath.reachesTarget){
            move();
        }        
    }

    private void move(){
        Debug.Log($"I'm moving from {currentPos} to {targetPos}");
    }
}
