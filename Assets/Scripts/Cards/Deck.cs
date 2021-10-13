using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    [SerializeField]
    //Creates a list for the cards which will be used to get the cards
    public List<Card> deck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //A method to get the Scriptable Object into the card
    public void getCard() 
    {
        Card newCard = deck[rndCard()];
        cardSwap(newCard);
    }

    //A method to generate and return a random number form 0 to 4, used for randomizing cards in the list
    public int rndCard()
    {
        float rndNum = Random.Range(0, 4);

        return (int)rndNum;
    }

    //Method to swap the Scriptable Object thats created for the card
    public void cardSwap(Card newCard) 
    {
        Card currentCard = GameObject.Find("Canvas").transform.GetChild(0).gameObject.GetComponent<cardDisplay>().card;
        currentCard = newCard;
    }

}
