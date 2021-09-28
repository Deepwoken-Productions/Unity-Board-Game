using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a singleton script, that means there is
//only meant to be one instance of these in the entire game OwO
//This script in particular handles the ordering of tiles in game into an array

public class TileOrderScript : MonoBehaviour
{
    public static TileOrderScript instance { get; private set; }

    //Setting where the tiles are located and declaring a transform array named tileOrder
    public Transform mapTiles;
    public Camera mainCamera;
    [HideInInspector]
    public Transform[] tileOrder;

    void Awake()
    {
        //Initializes and populates the tile order array
        InitializePopulateArray();

        //If there is no instances of this class, then define this instance as an instance of this class
       if(instance == null)
        {
            instance = this;
        }
       //If there're pre existing instances of this class then destroy them
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    void InitializePopulateArray()
    {
        //Caching the number of tiles in the map as a variable
        int tileNumber = mapTiles.childCount;

        //Initializing the array tileOrder
        tileOrder = new Transform[tileNumber];

        //Populating the array tileOrder, might add a sorthing algorithm here later
        for (int i = 0; i < tileNumber; i++)
        {
            tileOrder[i] = mapTiles.GetChild(i);
        }
    }
}
