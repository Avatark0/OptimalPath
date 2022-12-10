using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{ 
    public PathFinder pathFinder;

    public Vector2 currentPos;
    public Vector2 targetPos;

    public float movSpeed;
    public bool isMoving;

    private Path myPath;
    private bool hasPath;

    void Start(){
        if(pathFinder == null){
            pathFinder = GetComponent<PathFinder>();
        }

        currentPos = transform.position;
        targetPos = GameObject.FindGameObjectsWithTag("Target")[0].transform.position;
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

        Debug.Log($"I'm moving from {currentPos} to {myPath.pathList.First}");
    }
}
