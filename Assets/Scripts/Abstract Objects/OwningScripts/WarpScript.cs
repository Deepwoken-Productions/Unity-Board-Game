using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : TileScript
{
<<<<<<< Updated upstream:Assets/Scripts/Abstract Objects/OwningScripts/WarpScript.cs
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
=======
    public byte sendToTileNum = 0;
    public byte sendToMapLayer;

    public override void ActivateTile(PlayersScript player)
    {
        player.playerCurrentTile = sendToTileNum;
        player.TeleportToPos(sendToMapLayer);
>>>>>>> Stashed changes:Assets/Scripts/OwningScripts/WarpScript.cs
        Debug.Log("Trying To warp");
    }
}
