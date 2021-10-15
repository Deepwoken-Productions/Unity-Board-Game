using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public byte function;

    public Sprite artwork;

    public void Activate(PlayersScript curPly)
    {
        switch (function)
        {
            case 0:
                Debug.Log("Double Or Nothing");
                curPly.StartCoroutine(curPly.IterateOverTiles(false, DiceScript.instance.RollDice(2)));
                curPly.ForceActivateTile();
                break;
            case 1:
                Debug.Log("Quick Attack");
                curPly.Battle(TileOrderScript.instance.players[Random.Range(0, TileOrderScript.instance.players.Count)]);
                break;
            case 2:
                Debug.Log("Forfiet");
                int lossVal = 100;
                int owed;
                foreach (PlayersScript ply in TileOrderScript.instance.players)
                {
                    if (ply != curPly)
                    {
                        owed = Mathf.Min(curPly.Money, 100);
                        curPly.UpdateMoney(-lossVal);
                        ply.UpdateMoney(lossVal);
                    }
                }
                TileOrderScript.instance.UpdateUI();
                break;
        }
    }

}
