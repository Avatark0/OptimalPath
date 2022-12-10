using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborNodes
{
    public Dictionary<string, PathNode> dictionary;

    public NeighborNodes(){
        dictionary = new Dictionary<string, PathNode>();
        dictionary.Add("back", null);
        dictionary.Add("down", null);
        dictionary.Add("up", null);
        dictionary.Add("front", null);
    }

    public void ResetDictionary(){
        dictionary["back"] = null;
        dictionary["down"] = null;
        dictionary["up"] = null;
        dictionary["front"] = null;
    }
}
