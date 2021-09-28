using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is meant to set up the scriptable object Tiles,
//there is almost no reason to modify this script ever

[CreateAssetMenu(fileName = "Province", menuName = "Tiles")]

public class TileObject : ScriptableObject
{
    public int tileOrder;

    public string tileName;
    public short manpower;
    public short money;

    public Sprite sprite;
}
