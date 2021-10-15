using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public List<PlayersScript> TileCheck;
    bool Players = false;


    void Start()
    {
        TileCheck = TileOrderScript.instance.players;
        Debug.Log(TileCheck[0].playerCurrentTile);
        PlayerLoop();
    }

    public void PlayerLoop()
    {
        for(int i = 0; i < TileCheck.Count; i++)
        {
            Debug.Log("Num - " + i + (TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count));
            TileCheck = TileOrderScript.instance.players;
            if(TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count] != TileCheck[i] && 
                TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].playerCurrentTile == TileCheck[i].playerCurrentTile &&
                TileOrderScript.instance.turnCount > TileCheck.Count) // last if is "Moment of peace" rounds
            {
                Debug.Log("trying to fight" + TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName + " - " + TileCheck[i].userName);
                TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].Battle(TileCheck[i]);
            }
        }
    }

}
