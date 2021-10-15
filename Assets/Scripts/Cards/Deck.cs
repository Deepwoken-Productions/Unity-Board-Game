using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{

    [SerializeField]
    //Creates a list for the cards which will be used to get the cards
    public List<Card> deck;
    private List<Card> used = new List<Card>();
    public GameObject Parent;
    public Image image;
    public Text cardname;
    public Text description;

    InputMaps interaction;

    private void Start()
    {
        interaction = new InputMaps();
        Shuffle();
    }

    public void Shuffle()
    {
        int positionsRemaining = deck.Count;
        int newNum;
        List<Card> oldCards = new List<Card>(deck);
        //Loops through every card.
        for (int curCard = 0; curCard < deck.Count; curCard++)
        {
            //Choose a random spot from the remaining positions
            positionsRemaining--;
            //Subtract before and add here so that the range is 0 - 51 when starting
            newNum = Random.Range(0, positionsRemaining);
            //Sets the deck array to take the random index
            deck[curCard] = oldCards[newNum];
            //is a list literally just for that functionality.
            oldCards.RemoveAt(newNum);
        }
    }

    public void ReplenishDeck()
    {
        foreach(Card c in used)
        {
            deck.Add(c);
        }
        used.Clear();
        Shuffle();
    }

    public void DrawCard(PlayersScript ply, int times = 1)
    {
        StartCoroutine(OnKey(ply, times));

        
        
            
    }

    private IEnumerator OnKey(PlayersScript ply, int times)
    {
        ply.inUI = true;
        Parent.SetActive(true);
        for (int i = 0; i < times; i++)
        {
            image.sprite = deck[0].artwork;
            cardname.text = deck[0].name;
            description.text = deck[0].description;

            interaction.Enable();
            while (!interaction.KeyboardAndMouse.FlipCard.triggered)
            {
                yield return null;
            }
            interaction.Disable();
            deck[0].Activate(ply);
            used.Add(deck[0]);
            deck.RemoveAt(0);
            if(deck.Count == 0)
            {
                ReplenishDeck();
            }
        }
        Parent.SetActive(false);
        ply.inUI = false;
        TileOrderScript.instance.NextTurn();
    }

}
