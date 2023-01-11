using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSprite : MonoBehaviour
{
    private void OnEnable() {
        Target.TargetMovedEvent += Selfdestruct;
        WallSpawner.ToggleWallEvent += Selfdestruct;
    }

    private void OnDisable() {
        Target.TargetMovedEvent -= Selfdestruct;
        WallSpawner.ToggleWallEvent -= Selfdestruct;
    }

    public void Selfdestruct(){
        Destroy(gameObject);
    }
}
