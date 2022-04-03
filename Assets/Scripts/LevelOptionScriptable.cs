using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelOptions", menuName = "LevelOption")]
public class LevelOptionScriptable : ScriptableObject
{
    public bool isUsingWood;
    public bool isUsingStone;
    public bool isUsingWater;
    public bool isUsingDig;

    public int maxWood;
    public int maxStone;
    public int maxWater;
    public int maxDig;

    public int levelTime;
}
