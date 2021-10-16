using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTile : TileScript
{
    // Start is called before the first frame update
    public override void ActivateTile(PlayersScript player)
    {
        player.UpdateMoney(player.Money/2);
        player.UpdateTroops(player.Troops/2);
        player.inUI = true;
        StartCoroutine(Continue(player));
        
    }

    IEnumerator Continue(PlayersScript player)
    {
        interaction.Enable();
        TileOrderScript.instance.UIText.text = "This tile is cursed, you lost half your soldiers and troops! Press space to continue";
        while (!interaction.KeyboardAndMouse.FlipCard.triggered)
        {
            yield return null;
        }
        interaction.Disable();
        TileOrderScript.instance.UIText.text = "";
        player.inUI = false;
        TileOrderScript.instance.NextTurn();
    }
}
