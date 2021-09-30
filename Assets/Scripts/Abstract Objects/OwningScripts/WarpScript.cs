using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : TileScript
{
    public WarpObject tile;
    // Start is called before the first frame update
    void Start()
    {
        tileName = tile.tileName;
        tileOrder = tile.tileOrder;
    }

    public override void ActivateTile(PlayersScript player)
    {
        player.playerCurrentTile = tile.sendToTileNum;
        player.TeleportToPos();
        Debug.Log("Trying To warp");
    }
}
