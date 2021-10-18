using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public List<PlayersScript> TileCheck;
    bool Players = false;
    InputMaps interaction;


    void Start()
    {
        TileCheck = TileOrderScript.instance.players;
        interaction = new InputMaps();
    }

    public IEnumerator PlayerLoop(int i = 0)
    {
        interaction.Enable();
        for(; i < TileCheck.Count; i++)
        {
            TileCheck = TileOrderScript.instance.players;
            if(TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count] != TileCheck[i] && 
                TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].playerCurrentTile == TileCheck[i].playerCurrentTile &&
                TileOrderScript.instance.turnCount > TileCheck.Count) // last if is "Moment of peace" rounds
            {
                Debug.Log("trying to fight" + TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName + " - " + TileCheck[i].userName);

                int a = TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].Troops;
                int b = TileCheck[i].Troops;

                byte temp = TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].Battle(TileCheck[i]);

                a -= TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].Troops;
                b -= TileCheck[i].Troops;

                string c = TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName + " Is battling " + TileCheck[i].userName + ". "
                   + TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName +  " lost " + a + " troops, " + TileCheck[i].userName + " lost " + b + " troops. ";

                switch (temp)
                {
                    case 3:
                        c += TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName +  " and " + TileCheck[i].userName + "died! All the money was lost! ";

                        TileOrderScript.instance.RemovePlayer(TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count]);
                        break;
                    case 1:
                        c += TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName + " died! All the money was awarded to " + TileCheck[i].userName + "! ";

                        TileOrderScript.instance.RemovePlayer(TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count]);
                        
                        break;
                    case 2:
                        c += TileCheck[i].userName + " died! All the money was awarded to " + TileOrderScript.instance.players[TileOrderScript.instance.turnCount % TileOrderScript.instance.players.Count].userName + "! ";

                        TileOrderScript.instance.RemovePlayer(TileCheck[i]);
                        break;
                    case 0:
                        c += "The battle was a draw! ";
                        break;
                }
                c += "Press anything to continue.";

                TileOrderScript.instance.UIText.text = c;
                while (!interaction.KeyboardAndMouse.FlipCard.triggered)
                {
                    yield return null;
                }
                TileOrderScript.instance.UIText.text = "";

                
            }
        }
        interaction.Disable();
    }

}
