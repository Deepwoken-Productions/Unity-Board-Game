using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a singleton script, that means there is
//only meant to be one instance of these in the entire game OwO
//This script in particular handles the ordering of tiles in game into an array ~O_O~

public class TileOrderScript : MonoBehaviour
{
    public static TileOrderScript instance { get; private set; }

    //Setting where the tiles are located and declaring a transform array named tileOrder
    public Camera mainCamera;

    public List<Transform[]> tileOrders;

    public Transform[] maps;


    public List<PlayersScript> players;
    public Transform playerHoldingObject;
    //this value keep track of two things. 1) Who's turn it is (turncount % playercount) 2) turn count lol
    ushort turnCount = 0;



    void Awake()
    {
        tileOrders = new List<Transform[]>();

        //Initializes and populates the tile order array
        InitializePopulateArray();

        for (int i = 0; i < playerHoldingObject.childCount; i++)
        {
            //Adds all the players to the array
            players.Add(playerHoldingObject.GetChild(i).GetComponent<PlayersScript>());
            players[i].isTurn = false;
        }
        foreach (PlayersScript ps in players)
        {
            Debug.Log("init" + ps.userName);
        }

        //If there is no instances of this class, then define this instance as an instance of this class
        if (instance == null)
        {
            instance = this;
        }
        //If there're pre existing instances of this class then destroy them
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //Shuffle the list.
        int val = 0;
        int preSize = players.Count;
        PlayersScript tempCard;
        while (preSize > 0)
        {
            //Get the item to be moved randomly from the list (and preemptively shrink the list)
            val = Random.Range(0, preSize--);

            //Swap the last card with the card randomly chosen
            tempCard = players[preSize];
            players[preSize] = players[val];
            players[val] = tempCard;
        }
        //Jim Bob -- Choses 0
        //Bob Jim
        players[0].isTurn = true;
        foreach (PlayersScript ps in players)
        {
            Debug.Log(ps.userName);
        }
    }

    public void NextTurn()
    {
        players[turnCount % players.Count].isTurn = false;
        Debug.Log(players[turnCount % players.Count].userName +": " +  players[turnCount % players.Count].isTurn);
        players[++turnCount % players.Count].isTurn = true;
        Debug.Log(players[turnCount % players.Count].userName + ": " + players[turnCount % players.Count].isTurn);
    }

    void InitializePopulateArray()
    {
        for (int i = 0; i < maps.Length; i++)
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
