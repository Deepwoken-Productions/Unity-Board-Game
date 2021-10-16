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
    InputMaps interaction;
    private void Awake()
    {
        interaction = new InputMaps();
    }

    public void Activate(PlayersScript curPly)
    {
        switch (function)
        {
            case 0:
                Debug.Log("Double Or Nothing");
                
                int valA = DiceScript.instance.RollDice(1);

                string text  = "You rolled a: " + valA + " and gambled: $" + (valA * 100);

                int valB = DiceScript.instance.RollDice(1);
                int sum = 0;
                
                if (valB < 3)
                {
                    sum = valA * -100;
                    text += "... You lost it all! $" + sum + " Press anything to continue";
                }
                else
                {
                    sum = valA * 100;
                    text += "... You doubled your bet! $" + sum + " Press anything to continue"; 
                }
                curPly.UpdateMoney(sum);
                curPly.CheckIsAlive();

                TileOrderScript.instance.UIText.text = text;
                break;
            case 1:
                Debug.Log("Quick Attack");
                int val = Random.Range(0, TileOrderScript.instance.players.Count);
                curPly.Battle(TileOrderScript.instance.players[val]);
                //Move this into battlescript
                TileOrderScript.instance.UIText.text = "You Attacked: " + TileOrderScript.instance.players[val].userName + " Press anything to continue";

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
                TileOrderScript.instance.UIText.text = "You shared your wealth. Press anything to continue";
                TileOrderScript.instance.UpdateUI();
                break;
        }
    }

}
