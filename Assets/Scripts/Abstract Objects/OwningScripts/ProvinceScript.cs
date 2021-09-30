using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceScript : TileScript
{
    public ProvinceObject tile;

    protected ushort manpower;
    protected ushort money;

    // Start is called before the first frame update
    void Start()
    {
        manpower = tile.manpower;
        money = tile.money;
        tileName = tile.tileName;
        tileOrder = tile.tileOrder;
    }

    public override void ActivateTile(PlayersScript player)
    {
        // Would you like to buy object
    }
}
