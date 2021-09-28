using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that does stuff for tiles
public class TileScript : MonoBehaviour
{
    //Tileobject instance
    public TileObject tile;

    //Cached variables
    private int manpower;
    private int money;
    private string tileName;
    private int tileOrder;

    public bool selected;
    public string selectedPlayerName;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        //Grabs the mesh renderer of the tile
        meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
    }

    void Start()
    {
        //Setting cached variables
        money = tile.money;
        tileName = tile.tileName;
        manpower = tile.manpower;
        tileOrder = tile.tileOrder;

        //Making sure manpower and money are both integers above 0
        if (tile.manpower < 0)
        {
            manpower = 0;
        }
        else if (tile.money < 0)
        {
            money = 0;
        }
    }

    void Update()
    {

    }

    public void TextureTile(Material texture)
    {
        meshRenderer.material = texture;
    }
}
