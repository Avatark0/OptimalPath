using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(enemy, spawnPos(), Quaternion.identity, transform);
        }        
    }

    private Vector3 spawnPos(){
        int posX = -8;
        int posY = Random.Range(-4,5);

        return new Vector3(posX, posY, 0);
    }
}
