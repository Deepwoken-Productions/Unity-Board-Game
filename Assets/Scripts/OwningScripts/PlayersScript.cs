using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script that allows the player to do stuff
public class PlayersScript : MonoBehaviour
{

    //Declaring variables
    private Transform[] tileOrder;

    private Vector3 defaultCameraPosition;
    private float defaultCameraSize;

    [SerializeField]
    private short money = 0;

    public short Money
    {
        get { return money; }
    }


    [SerializeField]
    private short troops = 0;

    public short Troops
    {
        get { return troops; }
    }

    //Read only means it can be defined, but ONLY ONCE.
    public string userName;

    public byte playerCurrentTile = 0;
    private byte iteratorCurrentTile = 0;
    public byte defaultMapLayer;

    public float mouseSensitivity;

    private int currentDiceRoll;
    public byte zOffset;
    private bool isMoving;
    public bool isTurn;

    float zoom;
    float zoomDelta;

    private Camera mainCamera;

    public float movementInterval;

    private Vector3 playerMoveToPosition = Vector3.zero;
    public Vector3 playerPositionOnTile = Vector3.zero;

    private Vector2 currentMousePosition;
    InputMaps userInputMap;

    public Color highlightMaterial;
    public Color tileMaterial;

    Vector3 destinationPosition;

    public void UpdateTroops(int val)
    {
        troops += (short)val;
    }

    public void UpdateMoney(short val)
    {
        money += val;
    }

    public byte Battle(PlayersScript enemy)
    {
        short tempFriendlyTroops = troops;
        int diceRoll;

        //This value is the divisor
        int giveDice = 1000;

        short multiplyer = -100;

        diceRoll = DiceScript.instance.RollDice(Mathf.CeilToInt(enemy.troops / giveDice));
        UpdateTroops(diceRoll * multiplyer);

        diceRoll = DiceScript.instance.RollDice(Mathf.CeilToInt(tempFriendlyTroops / giveDice));
        enemy.UpdateTroops(diceRoll * multiplyer);


        if (CheckIsAlive())
        {
            return 2;
        }
        else if (enemy.CheckIsAlive())
        {
            return 1;
        }

        return 0;
    }

    public bool CheckIsAlive()
    {
        return true;
    }


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

    public void TeleportToPos(byte mapLayer) 
    {
        tileOrder = TileOrderScript.instance.tileOrders[mapLayer];
        playerMoveToPosition = tileOrder[playerCurrentTile].position;
    }

    void Start()
    {
        //Initializing variables
        tileOrder = TileOrderScript.instance.tileOrders[defaultMapLayer];
        mainCamera = TileOrderScript.instance.mainCamera;

        defaultCameraPosition = mainCamera.transform.position;
        defaultCameraSize = mainCamera.orthographicSize;

        //Moving the player into the "root" tile
        TeleportToPos(defaultMapLayer);

        //--Start of player input system code--//

        //When the player clicks their mouse do stuff
        userInputMap.KeyboardAndMouse.Click.performed += ctx => {

            //Raycasting from the player's current mouse position downwards
            RaycastHit2D raycastResults = Physics2D.Raycast(currentMousePosition, -mainCamera.transform.forward, 1000f);
            
            if (raycastResults)
            {
                //If the player or the iterator is not currently moving
                if (!isMoving && isTurn)
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
                    if(playerClickedTile >= 0)
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
                        if(moveDiceRoll == tileOrder.Length + 1)
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
            if (isTurn && !isMoving)
            {
                //Rolling 2 dice
                currentDiceRoll = DiceScript.instance.RollDice(2);

                //Highlighting the tiles that the player can move to
                StartCoroutine(IterateOverTiles(true, currentDiceRoll));

                Debug.Log(userName + "Has Right clicked");
            }
        };

        //When the player moves their mouse, update currentMousePosition
        userInputMap.KeyboardAndMouse.MousePosition.performed += ctx => {
            currentMousePosition = mainCamera.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        };

        userInputMap.KeyboardAndMouse.Zoom.performed += ctx => {
            zoomDelta += ctx.ReadValue<Vector2>().y;
            zoomDelta = Mathf.Clamp(zoomDelta, -1, 1);

            if(zoomDelta == 1)
            {
                destinationPosition = TileOrderScript.instance.currentPlayer.position;
            }
            else if(zoomDelta == -1)
            {
                destinationPosition = defaultCameraPosition;
            }
            else
            {
                destinationPosition = Vector3.zero;
            }
        };
    }

    void Update()
    {
        //Updating the player's position every frame
        UpdatePlayerPosition();

        if(destinationPosition != Vector3.zero)
        {
            Vector3 moveToPos = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(destinationPosition.x, destinationPosition.y, -10), 0.1f);

            mainCamera.transform.position = moveToPos;

            if(destinationPosition == TileOrderScript.instance.currentPlayer.position)
            {
                if(mainCamera.orthographicSize >= 3)
                {
                    mainCamera.orthographicSize -= 0.1f;
                }
            }
            else
            {
                if (mainCamera.orthographicSize <= 17)
                {
                    mainCamera.orthographicSize += 0.1f;
                }
            }

            destinationPosition = Vector3.zero;
        }
    }

    //If highlightTiles is true then tiles will be highlighted, if not player will move
    IEnumerator IterateOverTiles(bool highlightTiles, int diceRoll)
    {
            //Starting the debounce
            isMoving = true;

            //Setting the iterator's start position to the player's current position
            iteratorCurrentTile = playerCurrentTile;

            //Setting an internal dice roll counter to the dice roll specified, this dice roll counter will be incremented
            int diceRollCounter = diceRoll;

            Debug.Log(userName + " rolled a " + diceRoll + " im so proud of you UwU");

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
                Debug.Log("MOVING");
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
        if (!highlightTiles)
        {
            //Calls the tiles activate function
            Debug.Log(userName + "Has Ended their turn");
            tileOrder[playerCurrentTile].GetComponent<TileScript>().ActivateTile(this);
            TileOrderScript.instance.NextTurn();
        }
        isMoving = false;
        
    }
    

    public void UpdatePlayerPosition()
    {
        //If move to position isn't zero
        if(playerMoveToPosition != Vector3.zero)
        {
            //Move the player there and set the move to position as zero, might do some lerping here
            transform.position = playerMoveToPosition + playerPositionOnTile;
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
