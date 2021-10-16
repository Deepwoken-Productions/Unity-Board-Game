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

    //What are these for?
    public bool selected;
    public string selectedPlayerName;

    protected MeshRenderer meshRenderer;

    protected InputMaps interaction;

    protected void Awake()
    {
        //Grabs the mesh renderer of the tile
        interaction = new InputMaps();
        meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();
    }

    public void TextureTile(Color color)
    {
        meshRenderer.material.color = color;
    }

    public virtual void ActivateTile(PlayersScript player){}
}
