using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : TileScript
{
    public Deck ChanceDeck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateTile(PlayersScript player)
    {
        Debug.Log("Opening Shop");
    }
}
