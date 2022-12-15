using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSprite : MonoBehaviour
{
    private void OnEnable() {
        Target.TargetMoved += Selfdestruct;
    }

    private void OnDisable() {
        Target.TargetMoved -= Selfdestruct;
    }

    public void Selfdestruct(){
        Destroy(gameObject);
    }
}
