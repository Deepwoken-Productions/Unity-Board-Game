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
            TileCheck = TileOrderScript.instance.players;
            Debug.Log(TileCheck[i].playerCurrentTile);
            for(int p = 0; p < TileCheck.Count; p++)
            {
                if(i != p)
                {
                    if(TileOrderScript.instance.turnCount > TileCheck.Count)
                    {
                        Debug.Log(TileCheck[p].playerCurrentTile);
                        if (TileCheck[i].playerCurrentTile == TileCheck[p].playerCurrentTile)
                        {
                            TileCheck[i].Battle(TileCheck[p]);
                        }
                    }
                    
                }
            }
        }
    }

}
