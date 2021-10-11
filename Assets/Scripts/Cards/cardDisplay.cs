using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardDisplay : MonoBehaviour
{
    public Card card;
    [SerializeField] private GameObject CardBack;
    //Card Info
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;

    //For revealing the card
    public bool showCard = true;
    //For displaying text, so the player knows what key to press to continue
    public Text coverText;
   
    InputMaps playerInput;
    //Gets user to press SPACEBAR once
    bool canPress = true;

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Awake()
    {
        playerInput = new InputMaps();

        toggleCardBack(showCard);
        coverText.text = "Press SPACEBAR to continue!";

        playerInput.KeyboardAndMouse.FlipCard.performed += ctx =>
        {
            coverText.text = "";
            if (canPress)
            {
                toggleCardBack(false);
                canPress = false;
            }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
    }

    //A method to toggle the Image covering the Chance Card
    public void toggleCardBack(bool show) 
    {
        if (show) 
        {
            CardBack.SetActive(false);
        }
        else
        {
            CardBack.SetActive(true);
        }
        
    }
}
