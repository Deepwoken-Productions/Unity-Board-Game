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
    public Camera mainCamera;

    public List<Transform[]> tileOrders;
    public Transform[] maps;

    void Awake()
    {
        tileOrders = new List<Transform[]>();

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
        for(int i = 0; i < maps.Length; i++)
        {
            Transform mapTiles = maps[i];
            int mapTileNumber = mapTiles.childCount;

            Transform[] tileOrder = new Transform[mapTileNumber];
            tileOrders.Add(tileOrder);

            for (int z = 0; z < mapTileNumber; z++)
            {
                tileOrder[z] = mapTiles.GetChild(z);
            }
        }
    }
}
