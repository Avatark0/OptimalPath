using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathVisualizer : MonoBehaviour
{
    public GameObject pathSpriteInitializer;
    public static GameObject pathSprite;
    public static Transform parent;

    private void Start(){
        pathSprite = pathSpriteInitializer;
        parent = transform;
    }

    public static void SpawnPathSprite(PathNode node, int orderAdded){
        Vector3 pos = new Vector3(node.x, node.y, 0);
        GameObject sprite = GameObject.Instantiate(pathSprite, pos, Quaternion.identity, parent);
        sprite.GetComponent<Text>().text = orderAdded.ToString();
    }
}
