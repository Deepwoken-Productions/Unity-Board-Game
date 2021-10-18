using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceScript : TileScript
{
    public int startingTroops = 50;
    public int startingMoney = 50;
    public int troops = 0;
    public int money = 0;
    public int cost = 0;
    PlayersScript Owner;

    public override void ActivateTile(PlayersScript player)
    {
        player.inUI = true;
       StartCoroutine(OnTile(player));
    }

    private void Start()
    {
        
        ResetTile();
    }

    private void ResetTile()
    {
        troops = startingTroops;
        money = startingMoney;
    }

    private IEnumerator OnTile(PlayersScript player)
    {
        interaction.Enable();
        if (Owner != null)
        {
            int preTroops = player.Troops;
            int preMoney = player.Money;
            //Would you like to battle this tile? Owned by: Name. Press Y or N.
            TileOrderScript.instance.UIText.text = "Engaging in a battle against a land Owned by: " + Owner.userName +". Press space to continue";
            while (!interaction.KeyboardAndMouse.FlipCard.triggered)
            {
                yield return null;
            }
            if (player.Battle(this) == 1)
            {
                TileOrderScript.instance.UIText.text = "You won the battle Troops lost: " + (preTroops - player.Troops) + " and gained $" + (player.Money - preMoney) + " The land is now yours and has been reset. Press space to continue";
                UpdateOwner(player);
                ResetTile();
            }
            else
            {
                 if (!player.CheckIsAlive())
                {
                    TileOrderScript.instance.UIText.text = "You lost the battle and died! Your balance of $" + (preMoney - player.Money) + "was awared to: $" + Owner.userName + ". Press space to continue";
                    Owner.UpdateMoney(player.Money);
                    TileOrderScript.instance.RemovePlayer(player);
                }
                else
                {
                    TileOrderScript.instance.UIText.text = "You lost the battle Troops lost: " + (preTroops - player.Troops) + " and gained $" + (preMoney - player.Money) + ". Press space to continue";
                }
            }
            interaction.Disable();
            interaction.Enable();
        }
        else if (Owner == player)
        {
            TileOrderScript.instance.UIText.text = "You already own this land, you gained: " + troops + " troops and $" + money +". Press Space to continue.";
            player.UpdateTroops(troops);
            player.UpdateMoney(money);
            ResetTile();
        }
        else
        {
            if (player.Money >= cost)
            {
                //Would you like to buy this tile?
                TileOrderScript.instance.UIText.text = "Would you like to buy this land for $" + cost + "? This land holds " + troops + " troops and $" + money + " (Rewards granted when you land here again). Press Y for yes or N for no.";
                while(!interaction.KeyboardAndMouse.Yes.triggered && !interaction.KeyboardAndMouse.No.triggered)
                {
                    yield return null;
                }
                if (interaction.KeyboardAndMouse.Yes.triggered)
                {
                    TileOrderScript.instance.UIText.text = "You purched this land. Press space to continue.";
                    player.UpdateMoney(-cost);
                    UpdateOwner(player);
                }
                else if (interaction.KeyboardAndMouse.No.triggered)
                {
                    TileOrderScript.instance.UIText.text = "You did not purchase this land. Press space to continue.";
                }
            }
            else
            {
                TileOrderScript.instance.UIText.text = "You cannot afford this land. Press space to continue.";
            }
        }

        while (!interaction.KeyboardAndMouse.FlipCard.triggered)
        {
            yield return null;
        }

        interaction.Disable();
        player.inUI = false;
        TileOrderScript.instance.UIText.text = "";
        StartCoroutine(TileOrderScript.instance.battle.PlayerLoop());
        TileOrderScript.instance.NextTurn();
    }

    private void UpdateOwner(PlayersScript newOwner)
    {
        Owner = newOwner;
        meshRenderer.material = Owner.crownMat;
        TileOrderScript.instance.UpdateUI();

    }
}
