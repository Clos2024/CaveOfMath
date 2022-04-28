using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public enum States { Enter, Greet, Path, Battle, TakePath, Death }
public class PlayerMovement : MonoBehaviour
{
    public Transform Point1, Point2, Point3, Point4, Point5;
    public GameObject MathquestionManager;
    public GameObject PathChoose;
    public GameObject RoomTrackerComponent;
    public Light RoomLighting, RoomLighting2, RoomLighting3;
    public GameObject HPslider;
    Transform PlayerPickedPath;
    GameBoardManager gameBoardManager;
    RoomTracker roomTracker;
    PlayerHp playerHp;
    CreatureBehavior creatureBehavior;
    RoomPropManager roomPropManager;
    float gameTimer;
    public float playerSpeed;
    public bool greet, respawn, BeatBoss, pathOne, pathTwo, pathThree;
    public int playerMathLevel,pathOneTaken, pathTwoTaken, pathThreeTaken, randomCategory;
    public States playerState;

    // Start is called before the first frame update
    void Start()
    {
        roomPropManager = GetComponent<RoomPropManager>();
        RoomLighting.intensity = 0;
        RoomLighting2.intensity = 0;
        RoomLighting3.intensity = 0;
        playerMathLevel = 1;
        // When the player spawns set state to enter
        playerState = States.Enter;
        //This gets the GameBoardManager script and declares it as gameBoardManager
        gameBoardManager = MathquestionManager.GetComponent<GameBoardManager>();
        //This gets the RoomTracker script and declares it as roomTacker
        roomTracker = RoomTrackerComponent.GetComponent<RoomTracker>();
        //This gets the player HP script
        playerHp = gameObject.GetComponent<PlayerHp>();
        //amount of times a player has taken the paths
        pathOneTaken = 0;
        pathTwoTaken = 0;
        pathThreeTaken = 0;
    }

    private void Update()
    {
        switch (playerState)
        {
            case States.Enter:
                EnterState();
                break;
            case States.Greet:
                GreetState();
                break;
            case States.Battle:
                BattleState();
                break;
            case States.Path:
                PathState();
                break;
            case States.TakePath:
                TakePathState();
                break;
            case States.Death:
                DeathState();
                break;
        }

        if(playerHp.death == true)
        {
            playerState = States.Death;
        }
        if(creatureBehavior.BossOne == true || creatureBehavior.BossTwo == true || creatureBehavior.BossThree == true)
        {
            BeatBoss = true;
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
        }
    }
    void EnterState()
    {
        pathOne = false;
        pathTwo = false;
        pathThree = false;
        creatureBehavior = GameObject.FindGameObjectWithTag("Creature").GetComponent<CreatureBehavior>();
        FindObjectOfType<AudioManager>().StopPlaying("Footsteps");
        //Change players transform to Point1's transform
        transform.position = Point1.transform.position;
        //Timer that will change the player state after 5 seconds
        if (gameTimer >= 5.0f)
        {
            FindObjectOfType<AudioManager>().Play("Footsteps");
            playerState = States.Greet;
        }
        else
        {
            gameTimer += Time.deltaTime;
        }
        //Increase Room lighting till intensity equals 1
        if (RoomLighting.intensity <= 1)
        {
            var increaseRate = 0.2f;
            RoomLighting.intensity += increaseRate * Time.deltaTime;
            RoomLighting2.intensity += increaseRate * Time.deltaTime;
            RoomLighting3.intensity += increaseRate * Time.deltaTime;
        }
    }
    void GreetState()
    {
        //Now move player to position 2 when in the greet state
        if (transform.position.z <= Point2.transform.position.z)
        {
            transform.position -= Vector3.back * playerSpeed * Time.deltaTime;
        }
        //When the player is at position 2 change greet bool to true
        else
        {
            FindObjectOfType<AudioManager>().StopPlaying("Footsteps");
            greet = true;
        }

        if(creatureBehavior.creatureState == CreatureStates.Question)
        {
            playerState = States.Battle;
        }
    }
    void BattleState()
    {
        if(creatureBehavior == null)
        {
            playerState = States.Path;
        }
    }
    void PathState()
    {
        //change greet bool back to false
        greet = false;
        //activate UI elements with the path choice buttons
        PathChoose.SetActive(true);
    }
    //These functions are the ones tied to the UI buttons for path 1-3 once a function is called it sets the PlayerPickedPath variable to whatever point
    //corresponds with each function and then deactivates the path selection UI. 
    public void ChoosePathOne()
    {
        FindObjectOfType<AudioManager>().Play("Footsteps");
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        PlayerPickedPath = Point4;
        PathChoose.SetActive(false);
        playerState = States.TakePath;
        pathOneTaken++;
        GetCategoryGradeOne();
        playerMathLevel = randomCategory;
        pathOne = true;
        roomPropManager.pathOne++;
    }
    public void ChoosePathTwo()
    {
        FindObjectOfType<AudioManager>().Play("Footsteps");
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        PlayerPickedPath = Point5;
        PathChoose.SetActive(false);
        playerState = States.TakePath;
        pathTwoTaken++;
        GetCategoryGradeTwo();
        playerMathLevel = randomCategory;
        pathTwo = true;
        roomPropManager.pathTwo++;
    }
    public void ChoosePathThree()
    {
        FindObjectOfType<AudioManager>().Play("Footsteps");
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        PlayerPickedPath = Point3;
        PathChoose.SetActive(false);
        playerState = States.TakePath;
        pathThreeTaken++;
        GetCategoryGradeThree();
        playerMathLevel = randomCategory;
        pathThree = true;
        roomPropManager.pathThree++;
    }
    void TakePathState()
    {
        //If the players current position is less than the PlayerPickedPath then move towards that point
        if (transform.position.z <= PlayerPickedPath.transform.position.z)
        {
            //Look at the players picked point and move towards it
            var direction = (PlayerPickedPath.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
        else
        {
            //Once the player is at their point change their rotation to o and move forward
            Vector3 desiredRot = new Vector3(0, 0, 0);
            var lookRotation = Quaternion.LookRotation(desiredRot);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
        //If the player is past the room which is currently Z value of 2 then increase the rooms traveled and change the player back to enter state
        //moving them back to the start of the room also reset the gameTimer and gameBoard
        if (transform.position.z >= 2)
        {
            roomTracker.roomsTraveled += 1;
            gameTimer = 0;
            gameBoardManager.answerCorrect = false;
            playerState = States.Enter;
            //Set room light to 0
            RoomLighting.intensity = 0;
            RoomLighting2.intensity = 0;
            RoomLighting3.intensity = 0;

            if(BeatBoss)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    void DeathState()
    {
        var decreaseRate = 0.3f;
        RoomLighting.intensity -= decreaseRate * Time.deltaTime;
        RoomLighting2.intensity -= decreaseRate * Time.deltaTime;
        RoomLighting3.intensity -= decreaseRate * Time.deltaTime;

        HPslider.SetActive(false);

        if (RoomLighting.intensity <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    void GetCategoryGradeOne()
    {
        randomCategory = Random.Range(1, 3);
    }
    void GetCategoryGradeTwo()
    {
        randomCategory = Random.Range(4, 6);
    }
    void GetCategoryGradeThree()
    {
        randomCategory = Random.Range(7, 8);
    }
}

