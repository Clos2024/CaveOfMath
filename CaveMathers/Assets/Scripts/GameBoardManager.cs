using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardManager : MonoBehaviour
{
    public Text mainBox;
    public Text wrongAns;
    public Text choiceA;
    public Text choiceB;
    public Text choiceC;

    public GameObject roomTracker;
    RoomTracker roomCounter;
    public GameObject scoreTracker;
    ScoreTracker scoreCounter;
    int roomCount;

    string playerAnswer;
    string correct;

    public string wrongAnswer = "Uh oh! That one wasn't it, try another!";

    public bool answerCorrect, answerIncorrect;
    public bool questionGen = false;
    public int selection = 1;

    //Number of equaiton types (+, -, /, *)
    private int numQuestionType = 4;
    private int numWrongAnswers = 0;
    private int numStreakMult = 1;

    public GameObject player;

    PlayerMovement playerMovement;
    public Image MathQ1, MathQ2, MathQ3, MathQ4, MathQ5;

    private void Start()
    {
        scoreCounter = scoreTracker.GetComponent<ScoreTracker>();
        scoreCounter.currScore = 0;

        roomCounter = roomTracker.GetComponent<RoomTracker>();
        roomCount = roomCounter.roomsTraveled;
        roomCount++;

        playerMovement = player.GetComponent<PlayerMovement>();

        wrongAns.enabled = false;
    }

    //This Generates the Question
    public void GenerateQuestion()
    {
        roomCount = roomCounter.roomsTraveled;

        if (selection == 1)
        {
            Addition();
        }
        else if (selection == 2)
        {
            Subtraction();
        }
        else if (selection == 3)
        {
            Multiplication();
        }
        else if (selection == 4)
        {
            Division();
        }

        questionGen = true;
    }

    //Button A function to make playerAnswer A
    public void AnswerA()
    {
        //Debug.Log("Answer A");
        playerAnswer = "AnswerA";
        CheckAnswer();
    }

    //Button B function to make player Answer B
    public void AnswerB()
    {
        //Debug.Log("Answer B");
        playerAnswer = "AnswerB";
        CheckAnswer();
    }

    //Button C function to make player Answer C
    public void AnswerC()
    {
        //Debug.Log("Answer C");
        playerAnswer = "AnswerC";
        CheckAnswer();
    }

    //Checks if there is an answer if so then answer is correct this will be changed once we implement questions.
    public void CheckAnswer()
    {
        if(playerAnswer == correct)
        {
            answerCorrect = true;
            wrongAns.enabled = false;
            questionGen = false;
            if(numWrongAnswers == 0)
            {
                scoreCounter.currScore += (10 * numStreakMult);
                numStreakMult++;
            }
            else
            {
                scoreCounter.currScore += 10;
                numStreakMult = 1;
            }
        }
        else
        {
            answerCorrect = false;
            WrongAnswer();
        }
    }

    //Do something when the player guesses wrong, lose points? Add more roomms to run? Remove button
    public void WrongAnswer()
    {
        wrongAns.enabled = true;
    }

    public void Addition()
    {
        //Equation Variables
        int var1 = Random.Range(0 + (2 * roomCount), 9 + (2 * roomCount));
        int var2 = Random.Range(0 + (2 * roomCount), 9 + (2 * roomCount));
        int solution = var1 + var2;

        string equation = var1.ToString() + " + " + var2.ToString();
        string txtSol = solution.ToString();

        //Random Generator variables
        int correctAnswer = Random.Range(1, 3);

        int ranAnswer1 = Random.Range(0 + (2 * roomCount), 18 + (2 * roomCount));
        //Keep rolling if choice is same as correct solution
        while(ranAnswer1 == solution)
        {
            ranAnswer1 = Random.Range(0 + (2 * roomCount), 18 + (2 * roomCount));
        }

        int ranAnswer2 = Random.Range(0 + (2 * roomCount), 18 + (2 * roomCount));
        //Keep rolling if choice is same as correct solution or previous solution
        while (ranAnswer2 == solution || ranAnswer2 == ranAnswer1)
        {
            ranAnswer2 = Random.Range(0 + (2 * roomCount), 18 + (2 * roomCount));
        }


        string txtRan1 = ranAnswer1.ToString();
        string txtRan2 = ranAnswer2.ToString();

        mainBox.text = equation;

        if (correctAnswer == 1)
        {
            correct = "AnswerA";
            choiceA.text = txtSol;
            choiceB.text = txtRan1;
            choiceC.text = txtRan2;
        }
        else if(correctAnswer == 2)
        {
            correct = "AnswerB";
            //Assign button text
            choiceA.text = txtRan1;
            choiceB.text = txtSol;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 3)
        {
            correct = "AnswerC";
            //Assign button text
            choiceA.text = txtRan2;
            choiceB.text = txtRan1;
            choiceC.text = txtSol;
        }
    }

    public void Subtraction()
    {
        //Equation Variables
        int var1 = Random.Range(5 + (2 * roomCount), 9 + (2 * roomCount));
        int var2 = Random.Range(0 + (2 * roomCount), 5 + (2 * roomCount));
        int solution = var1 - var2;

        string equation = var1.ToString() + " - " + var2.ToString();
        string txtSol = solution.ToString();

        //Random Generator variables
        int correctAnswer = Random.Range(1, 3);

        int ranAnswer1 = Random.Range(0 + (2 * roomCount), 9 + (2 * roomCount));
        //Keep rolling if choice is same as correct solution
        while (ranAnswer1 == solution)
        {
            ranAnswer1 = Random.Range(0 + (2 * roomCount), 9 + (2 * roomCount));
        }

        int ranAnswer2 = Random.Range(0 + (2 * roomCount), 9 + (2 * roomCount));
        //Keep rolling if choice is same as correct solution or previous solution
        while (ranAnswer2 == solution || ranAnswer2 == ranAnswer1)
        {
            ranAnswer2 = Random.Range(0 + (2 * roomCount), 9 + (2 * roomCount));
        }


        string txtRan1 = ranAnswer1.ToString();
        string txtRan2 = ranAnswer2.ToString();

        mainBox.text = equation;

        if (correctAnswer == 1)
        {
            correct = "AnswerA";
            choiceA.text = txtSol;
            choiceB.text = txtRan1;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 2)
        {
            correct = "AnswerB";
            //Assign button text
            choiceA.text = txtRan1;
            choiceB.text = txtSol;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 3)
        {
            correct = "AnswerC";
            //Assign button text
            choiceA.text = txtRan2;
            choiceB.text = txtRan1;
            choiceC.text = txtSol;
        }
    }

    public void Multiplication()
    {
        //Equation Variables
        int var1 = Random.Range(1 + roomCount, 5 + roomCount);
        int var2 = Random.Range(0 + roomCount, 5 + roomCount);
        int solution = var1 * var2;

        string equation = var1.ToString() + " * " + var2.ToString();
        string txtSol = solution.ToString();

        //Random Generator variables
        int correctAnswer = Random.Range(1, 3);

        int ranAnswer1 = Random.Range(0 + roomCount, 25 + roomCount);
        //Keep rolling if choice is same as correct solution
        while (ranAnswer1 == solution)
        {
            ranAnswer1 = Random.Range(0 + roomCount, 25 + roomCount);
        }

        int ranAnswer2 = Random.Range(0 + roomCount, 25 + roomCount);
        //Keep rolling if choice is same as correct solution or previous solution
        while (ranAnswer2 == solution || ranAnswer2 == ranAnswer1)
        {
            ranAnswer2 = Random.Range(0 + roomCount, 25 + roomCount);
        }


        string txtRan1 = ranAnswer1.ToString();
        string txtRan2 = ranAnswer2.ToString();

        mainBox.text = equation;

        if (correctAnswer == 1)
        {
            correct = "AnswerA";
            choiceA.text = txtSol;
            choiceB.text = txtRan1;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 2)
        {
            correct = "AnswerB";
            //Assign button text
            choiceA.text = txtRan1;
            choiceB.text = txtSol;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 3)
        {
            correct = "AnswerC";
            //Assign button text
            choiceA.text = txtRan2;
            choiceB.text = txtRan1;
            choiceC.text = txtSol;
        }
    }

    public void Division()
    {
        //Equation Variables
        int var1 = Random.Range(1 + roomCount, 5 + roomCount);
        int var2 = Random.Range(0 + roomCount, 5 + roomCount);
        int solution = var1 / var2;

        string equation = var1.ToString() + " / " + var2.ToString();
        string txtSol = solution.ToString();

        //Random Generator variables
        int correctAnswer = Random.Range(1, 3);

        int ranAnswer1 = Random.Range(0 + roomCount, 25 + roomCount);
        //Keep rolling if choice is same as correct solution
        while (ranAnswer1 == solution)
        {
            ranAnswer1 = Random.Range(0 + roomCount, 25 + roomCount);
        }

        int ranAnswer2 = Random.Range(0 + roomCount, 25 + roomCount);
        //Keep rolling if choice is same as correct solution or previous solution
        while (ranAnswer2 == solution || ranAnswer2 == ranAnswer1)
        {
            ranAnswer2 = Random.Range(0 + roomCount, 25 + roomCount);
        }


        string txtRan1 = ranAnswer1.ToString();
        string txtRan2 = ranAnswer2.ToString();

        mainBox.text = equation;

        if (correctAnswer == 1)
        {
            correct = "AnswerA";
            choiceA.text = txtSol;
            choiceB.text = txtRan1;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 2)
        {
            correct = "AnswerB";
            //Assign button text
            choiceA.text = txtRan1;
            choiceB.text = txtSol;
            choiceC.text = txtRan2;
        }
        else if (correctAnswer == 3)
        {
            correct = "AnswerC";
            //Assign button text
            choiceA.text = txtRan2;
            choiceB.text = txtRan1;
            choiceC.text = txtSol;
        }
    }
}
