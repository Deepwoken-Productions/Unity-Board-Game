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
    //Please not this does not affect the play in game model cus I'm lazy
    public Sprite crown;
    public Material crownMat;

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
    public bool isMoving;
    public bool isTurn;

    public bool inUI = false;

    float zoom;
    float zoomDelta;

    private Camera mainCamera;

    public float movementInterval;

    public Vector3 playerMoveToPosition = Vector3.zero;
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

    public void UpdateMoney(int val)
    {
        money += (short)val;
    }

    public byte Battle(PlayersScript enemy)
    {
        short tempFriendlyTroops = troops;
        int diceRoll;

        //This value is the divisor
        int giveDice = 1000;

        short multiplyer = -100;

        diceRoll = DiceScript.instance.RollDice(Mathf.CeilToInt((float)enemy.troops / (float)giveDice));
        UpdateTroops(diceRoll * multiplyer);

        diceRoll = DiceScript.instance.RollDice(Mathf.CeilToInt((float)tempFriendlyTroops / (float)giveDice));
        enemy.UpdateTroops(diceRoll * multiplyer);

        if(!CheckIsAlive() && !enemy.CheckIsAlive())
        {
            return 3;
        }
        else if (!CheckIsAlive())
        {
            enemy.UpdateMoney(money);
            return 2;
        }
        else if (!enemy.CheckIsAlive())
        {
            money += enemy.Money;
            return 1;
        }
        return 0;
    }

    public byte Battle(ProvinceScript enemyLand)
    {
        short tempFriendlyTroops = troops;
        int diceRoll;

        //This value is the divisor
        int giveDice = 1000;

        short multiplyer = -100;
        short moneyMulti = 50;
        int temp = -enemyLand.troops;

        enemyLand.troops -= troops;
        UpdateTroops(temp);

        diceRoll = DiceScript.instance.RollDice(Mathf.CeilToInt((float)troops / (float)giveDice));

        UpdateMoney(Mathf.Min(enemyLand.money, diceRoll * moneyMulti));
        enemyLand.troops = diceRoll * multiplyer;


        if (!CheckIsAlive())
        {
            return 2;
        }
        else if (enemyLand.troops <= 0)
        {
            return 1;
        }

        return 0;
    }

    public bool CheckIsAlive()
    {
        return troops > 0 && money > 0;
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
                            StartCoroutine(IterateOverTiles(moveDiceRoll));
                        }
                    }
                }
            }
        };

        //When the player right clicks their mouse do stuff
        userInputMap.KeyboardAndMouse.RightClick.performed += ctx =>
        {
            if (isTurn && !isMoving && !inUI)
            {
                //Rolling 2 dice
                currentDiceRoll = DiceScript.instance.RollDice(2);

                //Highlighting the tiles that the player can move to
                StartCoroutine(IterateOverTiles(currentDiceRoll));

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
    public IEnumerator IterateOverTiles(int diceRoll)
    {
        if (isTurn)
        {
            //Starting the debounce
            isMoving = true;

            //Setting the iterator's start position to the player's current position
            iteratorCurrentTile = playerCurrentTile;

            //Setting an internal dice roll counter to the dice roll specified, this dice roll counter will be incremented
            int diceRollCounter = diceRoll;

            Debug.Log(userName + " rolled a " + diceRoll + " im so proud of you UwU");

            //While the current dice roll number is greater than 0
            while (diceRollCounter > 0)
            {
                //Wait the amount of time specified in the movement interval
                yield return new WaitForSeconds(movementInterval);

                //Increments the dice roll counter
                diceRollCounter--;

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
                
            }
            //Calls the tiles activate function
            tileOrder[playerCurrentTile].GetComponent<TileScript>().ActivateTile(this);
            if (!inUI) // Prevent escapes
            {
                TileOrderScript.instance.NextTurn();
            }
            isMoving = false;
        }
        
    }

    public void ForceActivateTile()
    {
        Debug.Log("ForceActivatedTile");
        tileOrder[playerCurrentTile].GetComponent<TileScript>().ActivateTile(this);
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

}
