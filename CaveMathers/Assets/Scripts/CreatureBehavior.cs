using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CreatureStates { idle, Greet, Question }
public class CreatureBehavior : MonoBehaviour
{
    public GameObject dialogueBox;

    public GameObject gameBoard;

    public Text dialogueText;

    float gameTimer;

    CreatureStates creatureState;

    public GameObject player;

    PlayerMovement playerMovement;

    bool dialogueBoxActive;

    public GameObject MathquestionManager;

    GameBoardManager gameBoardManager;

    // Start is called before the first frame update
    void Start()
    {
        // On spawn the creature state is idle
        creatureState = CreatureStates.idle;
        //This gets the PlayerMovement script and declares it as playerMovement
        playerMovement = player.GetComponent<PlayerMovement>();
        //This gets the GameBoardManager script and declares it as gameBoardManager
        gameBoardManager = MathquestionManager.GetComponent<GameBoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Switch case to change creature state and call each states function 
        switch (creatureState)
        {
            case CreatureStates.idle:
                idle();
                return;
            case CreatureStates.Greet:
                talk();
                return;
            case CreatureStates.Question:
                AskQuestion();
                return;
        }
    }
    //Idle state fucntion that checks if the player is in greet state
    void idle()
    {
        //If the player is in the greet state then change creatures state to Greet
        if(playerMovement.greet == true)
        {
            creatureState = CreatureStates.Greet;
        }
    }

    //Greet state function that activates a dialogue box asking the player to answer a math question
    void talk()
    {
        //When the function is called activate the dialogue box object and set the dialogueText to whatever we declare it to be
            dialogueBox.SetActive(true);
            dialogueText.text = "Hello answer my math question.";

        //After 3 seconds change creature state to question state
        if (gameTimer >= 3.0f)
        {
            creatureState = CreatureStates.Question;
        }
        else
        {
            gameTimer += Time.deltaTime;
        }
    }
    //Creature Question state function
    void AskQuestion()
    {
        //deactivate dialogueBox game object and set text to nothing
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        //activate the game board object
        gameBoard.SetActive(true);
        //calls GenerateAnswer from gameBoardManager
        if(!gameBoardManager.questionGen) gameBoardManager.GenerateQuestion();

        //If the answer is correct deactivate the gameBoard and change creature state to idle
        if(gameBoardManager.answerCorrect)
        {
            gameBoard.SetActive(false);
            creatureState = CreatureStates.idle;
        }
        if(gameBoardManager.answerIncorrect)
        {
            gameBoard.SetActive(false);
            creatureState = CreatureStates.Greet;
            gameTimer = 0;
        }
    }
}
