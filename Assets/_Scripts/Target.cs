using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void TargetMovedAction();
    public static event TargetMovedAction TargetMoved;

    private Vector3 position;

    private void Start() {
        position = transform.position;
    }

    private void Update() {
        if(position != transform.position){
            position = transform.position;
            if(TargetMoved != null){
                TargetMoved();
            }
        }    
    }
}
