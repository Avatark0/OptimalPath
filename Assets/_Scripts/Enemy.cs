using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{ 
    public PathNode currentPos;
    public PathNode targetPos;
    private const int NEXTITEM = 1;

    public PathFinder pathFinder;

    public float movSpeed;
    public bool isMoving;

    private Path myPath;
    private bool hasPath;

    void Start(){
        if(pathFinder == null)
            pathFinder = GameObject.FindGameObjectsWithTag("PathFinder")[0].GetComponent<PathFinder>();
    }

    void Update()
    {
        if(!hasPath){
            myPath = pathFinder.FindOptimalPath(currentPos, targetPos);
            hasPath = true;
        }
        else if(myPath.reachesTarget){
            move();
        }
    }

    private void move(){
        isMoving = true;

        Debug.Log($"I'm moving from {currentPos} to {myPath.nodeList[NEXTITEM]}");

        if(currentPos == myPath.nodeList[NEXTITEM]){
            isMoving = false;
        }
    }
}
