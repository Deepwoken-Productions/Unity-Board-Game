using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that does stuff for tiles
public class TileScript : MonoBehaviour
{

    //Tileobject instance
    //public TileObject tile;

    //Cached variables

    public string tileName;
    public byte tileOrder;

    public bool selected;
    public string selectedPlayerName;

    protected MeshRenderer meshRenderer;

    protected void Awake()
    {
        //Grabs the mesh renderer of the tile
        meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
    }

    public void TextureTile(Material texture)
    {
        meshRenderer.material = texture;
    }

    public virtual void ActivateTile(PlayersScript player) {}
}
