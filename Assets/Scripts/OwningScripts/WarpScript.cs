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
        Debug.Log("Trying To warp");
    }
}
