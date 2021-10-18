using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a singleton script, that means there is
//only meant to be one instance of these in the entire game OwO
//This script in particular handles dice rolls

public class DiceScript : MonoBehaviour
{
    public static DiceScript instance { get; private set; }

    public List<Sprite> diceCovers;
    public List<GameObject> Die;

    //The random number generator
    System.Random prng = new System.Random();

    private void Awake()
    {
        foreach (GameObject die in Die)
        {
            die.SetActive(false);
        }
        //If there is no instances of this class, then define this instance as an instance of this class
        if (instance == null)
        {
            instance = this;
        }
        //If there're pre existing instances of this class then destroy them
        else
        {
            Destroy(gameObject);
        }
    }

    //Roll dice method, rolls a defined amount of dice and returns the roll
    public int RollDice(int numberOfDice)
    {
        foreach(GameObject die in Die)
        {
            die.SetActive(false);
        }
        int diceRoll = 0;
        int cummies = 0; // UwU see this teacher ~~ Bilal

        for(int i = 0; i < numberOfDice; i++)
        {
            //Generates a random bumber between 1 - 6 and adds it to the dice roll integer
            cummies = prng.Next(1, 6);
            diceRoll += cummies;

            Die[i].GetComponent<SpriteRenderer>().sprite = diceCovers[cummies - 1];
            Die[i].SetActive(true);
        }

        return diceRoll;
    }

}
