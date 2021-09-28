using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a singleton script, that means there is
//only meant to be one instance of these in the entire game OwO
//This script in particular handles dice rolls

public class DiceScript : MonoBehaviour
{
    public static DiceScript instance { get; private set; }

    //The random number generator
    System.Random prng = new System.Random();

    private void Awake()
    {
        //If there is no instances of this class, then define this instance as an instance of this class
        if (instance == null)
        {
            instance = this;
        }
        //If there're pre existing instances of this class then destroy them
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    //Roll dice method, rolls a defined amount of dice and returns the roll
    public int RollDice( int numberOfDice)
    {
        int diceRoll = 0;

        for(int i = 0; i < numberOfDice; i++)
        {
            //Generates a random bumber between 1 - 6 and adds it to the dice roll integer
            diceRoll += prng.Next(1, 6);
        }

        return diceRoll;
    }

}
