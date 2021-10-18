using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : TileScript
{
    public byte sendToTileNum = 0;
    public byte sendToMapLayer;

    public override void ActivateTile(PlayersScript player)
    {
        player.playerCurrentTile = sendToTileNum;
        player.TeleportToPos(sendToMapLayer);
        player.inUI = true;
        StartCoroutine(Continue(player));
    }

    IEnumerator Continue(PlayersScript player)
    {
        interaction.Enable();
        TileOrderScript.instance.UIText.text = "You have been teleported! Press space to continue";
        while (!interaction.KeyboardAndMouse.FlipCard.triggered)
        {
            yield return null;
        }
        interaction.Disable();
        TileOrderScript.instance.UIText.text = "";
        player.inUI = false;
        StartCoroutine(TileOrderScript.instance.battle.PlayerLoop());
        TileOrderScript.instance.NextTurn();
    }
}
