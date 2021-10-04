using System.Collections;
using UnityEngine;

//The script that allows the player to do stuff
public class PlayersScript : MonoBehaviour
{

    //Declaring variables
    private Transform[] tileOrder;

    public byte playerCurrentTile = 0;
    private byte iteratorCurrentTile = 0;

    private int currentDiceRoll;
    public int zOffset;
    private bool isMoving;

    private Camera mainCamera;

    public float movementInterval;

    private Vector3 playerMoveToPosition = Vector3.zero;
    private Vector2 currentMousePosition;
    InputMaps userInputMap;

    public Material highlightMaterial;
    public Material tileMaterial;


    private void OnEnable()
    {
        userInputMap.Enable();
    }

    private void OnDisable()
    {
        userInputMap.Disable();
    }


    private void Awake()
    {
        //Just input stuff
        userInputMap = new InputMaps();
    }

    public void TeleportToPos() 
    {
        playerMoveToPosition = tileOrder[playerCurrentTile].position;
    }

    void Start()
    {
        //Initializing variables
        tileOrder = TileOrderScript.instance.tileOrder;
        mainCamera = TileOrderScript.instance.mainCamera;

        //Moving the player into the "root" tile
        TeleportToPos();

        //--Start of player input system code--//

        //When the player clicks their mouse do stuff
        userInputMap.KeyboardAndMouse.Click.performed += ctx => {

            //Raycasting from the player's current mouse position downwards
            RaycastHit2D raycastResults = Physics2D.Raycast(currentMousePosition, -mainCamera.transform.forward, Mathf.Infinity);
            
            if (raycastResults)
            {
                Debug.Log(raycastResults.transform.name);

                //If the player or the iterator is not currently moving
                if (!isMoving)
                {
                    //Player clicked tile is the index in the tileOrder array of the tile the player clicked on
                    int playerClickedTile = -1;

                    //Move dice roll is the dice roll that will be supplied into the iterateovertiles function
                    //to move the player to a specific tile
                    int moveDiceRoll;

                    //Figures out if the player clicked on a valid tile, if they did it sets playerclicked tile
                    //to an integer greater than -1
                    for(int i = 0; i < tileOrder.Length; i++)
                    {
                        if(raycastResults.transform == tileOrder[i].transform)
                        {
                            playerClickedTile = i;
                            break;
                        }
                    }

                    //If player clicked tile is greater than -1 then calculate a moveDiceRoll value
                    if (playerClickedTile >= 0)
                    {
                        //The tile script of playerClickedTile
                        TileScript playerClickedTileScript = tileOrder[playerClickedTile].GetComponent<TileScript>();

                        //Calculate distance between the playerClickedTile and playerCurrentTile if playerClickedTile is greater
                        if (playerClickedTile > playerCurrentTile)
                        {
                            moveDiceRoll = playerClickedTile - playerCurrentTile;
                        }
                        //If playerClickedTile is less than playerCurrentTile then do some math to calculate distance
                        else
                        {
                            moveDiceRoll = (tileOrder.Length - playerCurrentTile) + playerClickedTile;
                        }

                        //If distance is equal to the number of tiles in the map, then don't move the player at all
                        if (moveDiceRoll == tileOrder.Length + 1)
                        {
                            moveDiceRoll = 0;
                        }

                        //If the tile the player clicked on is highlighted and is set as selected by them then move them to said tile
                        if (playerClickedTileScript.selected == true && playerClickedTileScript.selectedPlayerName == transform.name)
                        {
                            StartCoroutine(IterateOverTiles(false, moveDiceRoll));
                        }
                    }
                }
            }
        };

        //When the player right clicks their mouse do stuff
        userInputMap.KeyboardAndMouse.RightClick.performed += ctx =>
        {
            //Rolling 2 dice
            currentDiceRoll = DiceScript.instance.RollDice(2);

            //Highlighting the tiles that the player can move to
            StartCoroutine(IterateOverTiles(true, currentDiceRoll));
        };

        //When the player moves their mouse, update currentMousePosition
        userInputMap.KeyboardAndMouse.MousePosition.performed += ctx => {
            currentMousePosition = mainCamera.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        };
    }

    void Update()
    {
        //Updating the player's position every frame
        UpdatePlayerPosition();
    }

    //If highlightTiles is true then tiles will be highlighted, if not player will move
    IEnumerator IterateOverTiles(bool highlightTiles, int diceRoll)
    {
        if (!isMoving)
        {
            //Starting the debounce
            isMoving = true;

            //Setting the iterator's start position to the player's current position
            iteratorCurrentTile = playerCurrentTile;

            //Setting an internal dice roll counter to the dice roll specified, this dice roll counter will be incremented
            int diceRollCounter = diceRoll;

            Debug.Log("You rolled a " + diceRoll + " im so proud of you UwU");

            //Unhighlights all selected tiles and deselects all tiles
            for (int i = 0; i < tileOrder.Length; i++)
            {
                TileScript tileScript = tileOrder[i].GetComponent<TileScript>();

                HighlightSelectTiles(false, null, tileScript);
            }

            //While the current dice roll number is greater than 0
            while (diceRollCounter > 0)
            {
                //Wait the amount of time specified in the movement interval
                yield return new WaitForSeconds(movementInterval);

                //Increments the dice roll counter
                diceRollCounter--;

                //If highlight tiles is off
                if (!highlightTiles)
                {
                    //Figuring out which tile the player's supposed to be on
                    if (playerCurrentTile < tileOrder.Length - 1)
                    {
                        playerCurrentTile++;
                    }
                    else
                    {
                        playerCurrentTile = 0;
                    }

                    //Moves the player to the position of the next tile
                    playerMoveToPosition = tileOrder[playerCurrentTile].position;
                }
                else
                {
                    //Figuring out which tile the iterator is supposed to be on
                    if (iteratorCurrentTile < tileOrder.Length - 1)
                    {
                        iteratorCurrentTile++;
                    }
                    else
                    {
                        iteratorCurrentTile = 0;
                    }

                    TileScript tileScript = tileOrder[iteratorCurrentTile].GetComponent<TileScript>();

                    //Highlighting the next tile and selecting it for a specific player
                    HighlightSelectTiles(true, transform.name, tileScript);
                }
            }

            //Ending the debounce
            isMoving = false;
            tileOrder[playerCurrentTile].GetComponent<TileScript>().ActivateTile(this);
        }
    }

    public void UpdatePlayerPosition()
    {
        //If move to position isn't zero
        if(playerMoveToPosition != Vector3.zero)
        {
            //Move the player there and set the move to position as zero, might do some lerping here
            transform.position = new Vector3(playerMoveToPosition.x, playerMoveToPosition.y, zOffset);
            playerMoveToPosition = Vector3.zero;
        }
    }

    //Highlights and selects tiles, pretty self explanatory code
    void HighlightSelectTiles(bool selected, string selectedPlayerName, TileScript tileScript)
    {
        if(selected && selectedPlayerName != null)
        {
            tileScript.selected = true;
            tileScript.selectedPlayerName = selectedPlayerName;
            tileScript.TextureTile(highlightMaterial);
        }
        else
        {
            tileScript.selected = false;
            tileScript.selectedPlayerName = null;
            tileScript.TextureTile(tileMaterial);
        }
    }

}
