using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public enum States { Enter, Greet, Path, TakePath }
public class PlayerMovement : MonoBehaviour
{
    public Transform Point1, Point2, Point3, Point4, Point5;

    public Text pathOne;
    public Text pathTwo;
    public Text pathThree;

    public GameObject MathquestionManager;
    public GameObject PathChoose;
    public GameObject RoomTrackerComponent;
    public Light RoomLighting;

    Transform PlayerPickedPath;

    GameBoardManager gameBoardManager;
    RoomTracker roomTracker;

    float gameTimer;
    public float playerSpeed;
    
    public bool greet;

    public int playerMathLevel;
    
    public States playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerMathLevel = 1;
        // When the player spawns set state to enter
        playerState = States.Enter;
        //This gets the GameBoardManager script and declares it as gameBoardManager
        gameBoardManager = MathquestionManager.GetComponent<GameBoardManager>();
        //This gets the RoomTracker script and declares it as roomTacker
        roomTracker = RoomTrackerComponent.GetComponent<RoomTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        //Switch case to change player state and call each states function
        switch (playerState)
        {
            case States.Enter:
                EnterState();
                //Debug.Log("I am in state enter");
                break;
            case States.Greet:
                GreetState();
                //Debug.Log("I am in state Greet");
                break;
            case States.Path:
                PathState();
                //Debug.Log("I am in state Path");
                break;
            case States.TakePath:
                TakePathState();
                //Debug.Log("I am in the take Path state");
                break;
        }
    }
    //This function is where the player is teleported to Point 1
    void EnterState()
    {
        greet = false;
        //Change players transform to Point1's transform
        transform.position = Point1.transform.position;

        //If the timer is greater than 3 then change the player state to green
        if (gameTimer >= 3.0f)
        {
            playerState = States.Greet;
        }
        //If the timer is less than 3 then count up every second.
        else
        {
            gameTimer += Time.deltaTime;
        }
        //increases the lighting in the room back to 1 intensity
        if(RoomLighting.intensity <= 1)
        {
            RoomLighting.intensity += Time.deltaTime;
        }
    }

    // This function is where the player walks up to greet the creature.
    void GreetState()
    {
        //If the players transform isnt greater than Point 2 transform then move forward
        if (transform.position.z <= Point2.transform.position.z)
        {
            transform.position -= Vector3.back * playerSpeed * Time.deltaTime;
        }
        //If the players transform is greater than Point 2 stop and change the greet bool to tru
        else
        {
            greet = true;
        }
        //if the gameBoardManager says the answer is correct change the player into the path state
        if (gameBoardManager.answerCorrect)
        {
            playerState = States.Path;
        }

    }

    //This function is where the player chooses what Path to take after completing a Math Question
    void PathState()
    {
        //change greet bool back to false
        greet = false;
        //activate UI elements with the path choice buttons
        int numPathOne = Random.Range(1, 4);
        int numPathTwo = Random.Range(1, 4);
        while(numPathOne == numPathTwo)
        {
            numPathTwo = Random.Range(1, 4);
        }
        int numPathThree = Random.Range(1, 4);
        while(numPathThree == numPathTwo || numPathThree == numPathOne)
        {
            numPathThree = Random.Range(1, 4);
        }

        PathChoose.SetActive(true);
    }

    // This function is where the player moves to their selected path
    void TakePathState()
    {
        //If the players current position is less than the PlayerPickedPath then move towards that point
        if (transform.position.z <= PlayerPickedPath.transform.position.z)
        {
            //Look at the players picked point and move towards it
            transform.LookAt(PlayerPickedPath, Vector3.up);
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
        else
        {
            //Once the player is at their point change their rotation to o and move forward
            Vector3 desiredRot = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(desiredRot);
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
        //If the player is past the room which is currently Z value of 2 then increase the rooms traveled and change the player back to enter state
        //moving them back to the start of the room also reset the gameTimer and gameBoard
        if(transform.position.z >= 2)
        {
            roomTracker.roomsTraveled += 1;
            gameTimer = 0;
            gameBoardManager.answerCorrect = false;
            playerState = States.Enter;
            //Set room light to 0
            RoomLighting.intensity = 0;
        }
    }

    //These functions are the ones tied to the UI buttons for path 1-3 once a function is called it sets the PlayerPickedPath variable to whatever point
    //corresponds with each function and then deactivates the path selection UI. 
    public void ChoosePathOne()
    {
        gameBoardManager.selection = 1;
        PlayerPickedPath = Point4;
        PathChoose.SetActive(false);
        playerState = States.TakePath;
    }
    public void ChoosePathTwo()
    {
        gameBoardManager.selection = 2;
        PlayerPickedPath = Point5;
        PathChoose.SetActive(false);
        playerState = States.TakePath;
    }
    public void ChoosePathThree()
    {
        gameBoardManager.selection = 3;
        PlayerPickedPath = Point3;
        PathChoose.SetActive(false);
        playerState = States.TakePath;
    }
}
