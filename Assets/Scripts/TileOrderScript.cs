using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This is a singleton script, that means there is
//only meant to be one instance of these in the entire game OwO
//This script in particular handles the ordering of tiles in game into an array ~O_O~

public class TileOrderScript : MonoBehaviour
{
    public static TileOrderScript instance { get; private set; }

    //Setting where the tiles are located and declaring a transform array named tileOrder
    public Camera mainCamera;

    public BattleScript battle;

    public List<Transform[]> tileOrders;

    public Transform Players;

    public Transform[] maps;


    public List<PlayersScript> players;

    //Make not seriealized. Or get set.
    public Transform currentPlayer;

    public Transform UI;

    public Text UIText;

    public short startingMoney;
    public short startingTroops;

    public Transform playerHoldingObject;
    //this value keep track of two things. 1) Who's turn it is (turncount % playercount) 2) turn count lol
    public ushort turnCount = 0;



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
            players[i].UpdateMoney(-players[i].Money + startingMoney);
            players[i].UpdateTroops(-players[i].Troops + startingTroops);
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
        currentPlayer = players[0].transform;
        UpdateUI();
    }

    public void NextTurn()
    {
        Debug.Log(players[turnCount % players.Count].userName + "Has Ended their turn");
        players[turnCount % players.Count].isTurn = false;
        players[turnCount % players.Count].isMoving = false;
        players[++turnCount % players.Count].isTurn = true;
        currentPlayer = players[turnCount % players.Count].transform;
        UpdateUI();
        StartCoroutine(CheckWin());
    }

    public void UpdateUI()
    {
        Debug.Log("Updating UI");
        //Bad code, but I'm too lazy to do this right. -- Needa make a public int start or read the names otherwise
        for (int i = 3; i < UI.childCount && i < players.Count + 3; i++)
        {
            UI.GetChild(i).GetChild(0).GetComponent<Text>().text = players[(turnCount + i - 3) % players.Count].userName;
            UI.GetChild(i).GetChild(1).GetComponent<Text>().text = "Troops: " + players[(turnCount + i - 3) % players.Count].Troops;
            UI.GetChild(i).GetChild(2).GetComponent<Text>().text = "Money: " + players[(turnCount + i - 3) % players.Count].Money;
            UI.GetChild(i).GetChild(3).GetComponent<Image>().sprite = players[(turnCount + i - 3) % players.Count].crown;
        }
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

    public void RemovePlayer(PlayersScript ply)
    {
        Destroy(UI.GetChild(2  + (players.Count)).gameObject);
        Destroy(Players.GetChild(players.IndexOf(ply)).gameObject);
        players.Remove(ply);
        UpdateUI();
    }

    public IEnumerator CheckWin()
    {
       if(players.Count == 1)
       {
            UIText.text = players[0] + " WINS! Total turns: " + turnCount;
            yield return new WaitForSeconds(20);
            SceneManager.LoadScene("MainMenu");
       }
    }
}
