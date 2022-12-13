using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public PathFinder pathFinder;
    private LinkedList<PathNode> myPath;
    
    private int nodeCount;

    private bool hasPath;
    private bool reachedNextNode;
    private bool reachedTarget;

    private Vector2 targetPos;

    public float movSpeed;
    public float proximityThereshold;

    void Start(){
        if(pathFinder == null){
            pathFinder = GetComponent<PathFinder>();
        }

        targetPos = GameObject.FindGameObjectsWithTag("Target")[0].transform.position;
    }

    void Update()
    {
        if(!reachedTarget){
            if(!hasPath){
                myPath = pathFinder.FindOptimalPath(transform.position, targetPos);
                
                myPath.RemoveFirst();
                if(myPath.Count == 0){
                    reachedTarget = true;
                } 
                else {
                    hasPath = true;

                    nodeCount = myPath.Count;
                    foreach(PathNode node in myPath){
                        PathVisualizer.SpawnPathSprite(node, nodeCount--);
                    }
                }
            }
            else if(!reachedNextNode){
                Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                Vector2 distanceToNextNode = myPath.First.Value.pos - pos;
                if(distanceToNextNode.magnitude < proximityThereshold){
                    reachedNextNode = true;
                }
                transform.Translate(distanceToNextNode.normalized * movSpeed * Time.deltaTime);
            }
            else {
                reachedNextNode = false;
                
                myPath.RemoveFirst();
                if(myPath.Count == 0){
                    reachedTarget = true;
                }
            } 
        }
    }
}
