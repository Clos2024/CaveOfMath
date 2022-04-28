using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CreatureStates { idle, Greet, Question, CheckAnswer, death }
public class CreatureBehavior : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject gameBoard;
    public Text dialogueText,nameText;
    float gameTimer;
    public CreatureStates creatureState;
    PlayerMovement playerMovement;
    RoomTracker roomTracker;
    CorrectAnswers correctAnswers;
    GameBoardManager gameBoardManager;
    EnemyHP enemyHP;
    PlayerHp playerHP;
    GameObject healthBar;
    bool dialogueBoxActive;
    public bool wolf, spider, rat, BossOne, BossTwo, BossThree, introDialogue, repeatDialogue, failedDialogue;
    Animator s_animator;
    public GameObject SmokePuff, starshit;
    GameObject creatureOrigin;
    string Name;

    // Start is called before the first frame update
    private void Awake()
    {
        s_animator = GetComponent<Animator>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameBoardManager = GameObject.Find("MathQuestionManager").GetComponent<GameBoardManager>();
        roomTracker = GameObject.Find("Canvas/Rooms").GetComponent<RoomTracker>();
        correctAnswers = GameObject.Find("Answers correct").GetComponent<CorrectAnswers>();
        playerHP = GameObject.Find("Player").GetComponent<PlayerHp>();
        gameBoard = GameObject.Find("Canvas/MathQuestionManager/GameBoardGroup");
        dialogueBox = GameObject.Find("Canvas/DialogueBoxContainer/DialogueBox");
        dialogueText = GameObject.Find("Canvas/DialogueBoxContainer/DialogueBox/DialogueText").GetComponent<Text>();
        enemyHP = GetComponent<EnemyHP>();
        healthBar = GameObject.Find("Canvas/EnemyHealthBarHolder/EnemyHealthBar");
        creatureOrigin = GameObject.Find("CreatureSpawner/CreatureOrigin");
    }
    void Start()
    {
        // On spawn the creature state is idle
        creatureState = CreatureStates.idle;
        gameBoard.SetActive(false);
        dialogueBox.SetActive(false);
        introDialogue = true;
        if (BossOne == true || BossTwo == true || BossThree == true)
        {
            FindObjectOfType<AudioManager>().Play("BossTheme");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Switch case to change creature state and call each states function 
        switch (creatureState)
        {
            case CreatureStates.idle:
                idleState();
                return;
            case CreatureStates.Greet:
                GreetState();
                return;
            case CreatureStates.Question:
                QuestionState();
                return;
            case CreatureStates.CheckAnswer:
                CheckAnswer();
                return;
            case CreatureStates.death:
                DeathState();
                return;
        }
    }
    void idleState()
    {
        s_animator.SetBool("SpiderEnter", true);
        s_animator.SetBool("MouseIdle", true);
        s_animator.SetBool("WolfIdle", true);

        //If the player has set the greet bool to true transition into the creatures greet state
        if (playerMovement.greet == true)
        {
            creatureState = CreatureStates.Greet;

            if (spider)
            {
                FindObjectOfType<AudioManager>().Play("Spider");
            }
            else if (wolf)
            {
                FindObjectOfType<AudioManager>().Play("WolfBark");
            }
            else if (rat)
            {
                FindObjectOfType<AudioManager>().Play("Rat");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Spider");
            }
        }
    }
    void GreetState()
    {
        s_animator.SetBool("SpiderEnter", false);
        s_animator.SetBool("SpiderIdle", true);

        if (playerMovement.playerState != States.Death)
        {
            //Turn on dialogue box
            dialogueBox.SetActive(true);
            //Turn off GameBaord
            gameBoard.SetActive(false);

            //Set what is in the dialogue box here
            if (introDialogue)
            {
                if (playerMovement.BeatBoss != true)
                {
                    Debug.Log("Intro Dial");
                    if (roomTracker.roomsTraveled == 0)
                    {
                        dialogueText.text = "Halt! You must answer my question to pass.";
                    }
                    else if (roomTracker.roomsTraveled == 1)
                    {
                        dialogueText.text = "The cave has beaten smarter people than you! Now try this on for size.";
                    }
                    else if (roomTracker.roomsTraveled == 2)
                    {
                        dialogueText.text = "You think you can escape! HA-HAHA-HA nice joke. You we're... joking right?";
                    }
                    else if (roomTracker.roomsTraveled == 3)
                    {
                        dialogueText.text = "You think you're smart because you beat those bozos. Time for a real challenge.";
                    }
                    else if (roomTracker.roomsTraveled == 4)
                    {
                        dialogueText.text = "Ow I see you beat arrogant andy over there. Listen kid this is do or die time.";
                    }
                    else if (roomTracker.roomsTraveled == 5)
                    {
                        dialogueText.text = "This cave is endless as far as you're concerned.";
                    }
                    else if (roomTracker.roomsTraveled == 6)
                    {
                        dialogueText.text = "Im gonna fortnite dance on you after you FAIL!";
                    }
                    else if (roomTracker.roomsTraveled == 7)
                    {
                        dialogueText.text = "So sad that you've come this far just to lose. SAD!";
                    }
                    else if (roomTracker.roomsTraveled == 8)
                    {
                        dialogueText.text = "I dont need to be a fortune teller to see failure in your future.";
                    }
                    else if (roomTracker.roomsTraveled == 9)
                    {
                        dialogueText.text = "Learn to live with losses since you're gonna be experience it alot.";
                    }
                    else
                    {
                        dialogueText.text = "The end is near for you HAHAHAHAHAHA.";
                    }
                }
                else
                {
                    dialogueText.text = "Think you're tough huh. Lets see if you can handle a BIG BOSS like me.";
                }
            }
            else if (repeatDialogue)
            {
                s_animator.SetBool("MouseHit", true);
                s_animator.SetBool("MouseIdle", false);
                s_animator.SetBool("WolfHit", true);
                s_animator.SetBool("WolfIdle", false);
                Debug.Log("Repeat Dial");
                if (enemyHP.CurrentHealth == 14f)
                {
                    dialogueText.text = "You have to be a special kind of genius to escape the cave.";
                }
                else if (enemyHP.CurrentHealth == 12f)
                {
                    dialogueText.text = "Oh look you payed attention in class and got it right. Well kid this isnt class anymore it's the CAVE OF MATH!";
                }
                else if (enemyHP.CurrentHealth == 12f)
                {
                    dialogueText.text = "The cave wants answers and I want to see you fail. Why? Cause I'm better than you HAHAHAHA!";
                }
                else if (enemyHP.CurrentHealth == 10f)
                {
                    dialogueText.text = "Addition, Subtraction, I'm looking for some quick action. God I'm a genius.";
                }
                else if (enemyHP.CurrentHealth == 8f)
                {
                    dialogueText.text = "Listen here bud I ask the questions and you fail! Thats how this goes.";
                }
                else if (enemyHP.CurrentHealth == 6f)
                {
                    dialogueText.text = "Oh wow! Look at me I'm in a cave and can answer math questions.";
                }
                else if (enemyHP.CurrentHealth == 4f)
                {
                    dialogueText.text = "Hold on lets talk about this. There's no need for violence";
                }
                else if (enemyHP.CurrentHealth == 2f)
                {
                    dialogueText.text = "What!? Lucky guess. B-b-but you won't get this one right!";
                }
                else if (enemyHP.CurrentHealth == 0f)
                {
                    dialogueText.text = "No way! You won't make it out the Boss will make sure of that.";
                }
            }
            else if (failedDialogue)
            {
                if (playerHP.CurrentHealth == 4f)
                {
                    dialogueText.text = "Keep that up and you'll never escape HAHAHAHA!";
                }
                else if (playerHP.CurrentHealth == 2f)
                {
                    dialogueText.text = "Is this the best you got. I'm not impressed.";
                }
                else if (playerHP.CurrentHealth == 0f)
                {
                    dialogueText.text = "See you back at the start of the cave!";
                }
            }

            //Activates enemy health bar
            healthBar.SetActive(true);
            //The creature state will change after the dialogue has been on screen for 10 seconds or the player presses mouse 1
            if (gameTimer >= 10.0f || Input.GetButtonDown("Fire1"))
            {
                if (enemyHP.death == false)
                {
                    creatureState = CreatureStates.Question;
                }
                else
                {
                    creatureState = CreatureStates.death;
                }
            }
            else
            {
                gameTimer += Time.deltaTime;
            }
        }
        else
        {
            gameBoard.SetActive(false);
            healthBar.SetActive(false);
        }
    }
    void QuestionState()
    {
        s_animator.SetBool("MouseIdle", true);
        s_animator.SetBool("MouseHit", false);

        s_animator.SetBool("WolfHit", false);
        s_animator.SetBool("WolfIdle", true);
        introDialogue = false;
        //Hide the dialogue box
        dialogueBox.SetActive(false);
        //Set the dialogue text to nothing
        dialogueText.text = "";
        //Display the GameBoard now
        FindObjectOfType<AudioManager>().Play("GameBoardPopup");
        gameBoard.SetActive(true);
        //If the GameBoard does not have a question generate a question and then have the creature enter his CheckAnswer state.
        if (gameBoardManager.questionAsked == null)
        {
            gameBoardManager.GenerateQuestion();
            creatureState = CreatureStates.CheckAnswer;
        }
    }
    void CheckAnswer()
    {
            if (gameBoardManager.answerCorrect)
            {
                FindObjectOfType<AudioManager>().Play("Correct");
                enemyHP.TakeDamage();
                GameObject.Instantiate(starshit, creatureOrigin.transform);
                correctAnswers.saveAnswers();
                GetNewQuestionCategory();
                Destroy(gameBoardManager.questionAsked);
                gameBoardManager.questionAsked = null;
                gameTimer = 0f;
                repeatDialogue = true;
                failedDialogue = false;
                creatureState = CreatureStates.Greet;
        }
            if(gameBoardManager.answerIncorrect)
            {
                FindObjectOfType<AudioManager>().Play("Hurt");
                playerHP.TakeDamage();
                GetNewQuestionCategory();
                Destroy(gameBoardManager.questionAsked);
                gameBoardManager.questionAsked = null;
                gameTimer = 0f;
                failedDialogue = true;
                repeatDialogue = false;
                creatureState = CreatureStates.idle;
            }
    }
    void DeathState()
    {
        GameObject.Instantiate(SmokePuff, creatureOrigin.transform);
        FindObjectOfType<AudioManager>().Play("SmokePuff");
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        gameBoard.SetActive(false);
        healthBar.SetActive(false);
        FindObjectOfType<AudioManager>().StopPlaying("BossTheme");
        Destroy(gameObject);
    }
    void GetNewQuestionCategory()
    {
        if(playerMovement.playerMathLevel == 1)
        {
            playerMovement.playerMathLevel = 2;
        }
        else if (playerMovement.playerMathLevel == 2)
        {
            playerMovement.playerMathLevel = 3;
        }
        else if (playerMovement.playerMathLevel == 3)
        {
            playerMovement.playerMathLevel = 1;
        }
        else if (playerMovement.playerMathLevel == 4)
        {
            playerMovement.playerMathLevel = 5;
        }
        else if (playerMovement.playerMathLevel == 5)
        {
            playerMovement.playerMathLevel = 6;
        }
        else if (playerMovement.playerMathLevel == 6)
        {
            playerMovement.playerMathLevel = 4;
        }
        else if (playerMovement.playerMathLevel == 7)
        {
            playerMovement.playerMathLevel = 8;
        }
        else if (playerMovement.playerMathLevel == 8)
        {
            playerMovement.playerMathLevel = 7;
        }
    }
}
