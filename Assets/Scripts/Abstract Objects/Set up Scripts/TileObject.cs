using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is ment to set up the scriptable object Tiles,
//there is almost no reason to modify this script ever

[CreateAssetMenu(fileName = "Province", menuName = "EmptyTile")]

public class TileObject : ScriptableObject
{
    public byte tileOrder;
    public string tileName;

    public Sprite sprite;
}
