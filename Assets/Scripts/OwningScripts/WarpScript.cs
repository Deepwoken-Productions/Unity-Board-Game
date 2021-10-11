using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : TileScript
{
    public byte sendToTileNum = 0;

    public override void ActivateTile(PlayersScript player)
    {
        player.playerCurrentTile = sendToTileNum;
        player.TeleportToPos();
        Debug.Log("Trying To warp");
    }
}
