using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardManager : MonoBehaviour
{
    string playerAnswer;
    public bool answerCorrect, answerIncorrect;
    public Text AButton, BButton, CButton;
    public Text pathOneCat, pathTwoCat, pathThreeCat;
    public GameObject player;
    PlayerMovement playerMovement;
    Categories categories;
    public Transform QuestionOrigin;
    public int Category, countUp;
    public int random1, random2, random3;
    public GameObject questionAsked;
    QuestionValues questionValue;
    string answer;
    int add, sub, coin, time, place, round, greater, multi;
    public int pathOne, pathTwo, pathThree;

    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        categories = GetComponent<Categories>();

        //assign categories a int number
        add = 1;
        sub = 2;
        coin = 3;
        time = 4;
        place = 5;
        round = 6;
        greater = 7;
        multi = 8;
        countUp = 0;

        //category equals player math level
        Category = playerMovement.playerMathLevel;
    }
    public void GenerateQuestion()
    {
        //The category is what ever the playersMathLevel is when GenerateQuestion function is called
        Category = playerMovement.playerMathLevel;
        //resets answer bools
        answerCorrect = false;
        answerIncorrect = false;
        //If no question current exist generate a question based off what category the player in on then pick a random point in the respected categories array
        if (questionAsked == null)
        {
            if (Category == add)
            {
                var arrayRange = categories.additionQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.additionQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.additionQuestions[randomRange].GetHashCode();
                categories.additionQuestions = cleanArray(categories.additionQuestions,tempHashCode);
            }
            else if (Category == sub)
            {
                var arrayRange = categories.subtractionQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.subtractionQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.subtractionQuestions[randomRange].GetHashCode();
                categories.subtractionQuestions = cleanArray(categories.subtractionQuestions, tempHashCode);
            }
            else if (Category == coin)
            {
                var arrayRange = categories.coinvalueQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.coinvalueQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.coinvalueQuestions[randomRange].GetHashCode();
                categories.coinvalueQuestions = cleanArray(categories.coinvalueQuestions, tempHashCode);
            }
            else if (Category == time)
            {
                var arrayRange = categories.timeQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.timeQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.timeQuestions[randomRange].GetHashCode();
                categories.timeQuestions = cleanArray(categories.timeQuestions, tempHashCode);
            }
            else if (Category == place)
            {
                var arrayRange = categories.placevalueQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.placevalueQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.placevalueQuestions[randomRange].GetHashCode();
                categories.placevalueQuestions = cleanArray(categories.placevalueQuestions, tempHashCode);
            }
            else if (Category == round)
            {
                var arrayRange = categories.roundQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.roundQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.roundQuestions[randomRange].GetHashCode();
                categories.roundQuestions = cleanArray(categories.roundQuestions, tempHashCode);
            }
            else if (Category == greater)
            {
                var arrayRange = categories.greaterlessQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.greaterlessQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.greaterlessQuestions[randomRange].GetHashCode();
                categories.greaterlessQuestions = cleanArray(categories.greaterlessQuestions, tempHashCode);
            }
            else if (Category == multi)
            {
                var arrayRange = categories.multiQuestions.Length;
                var randomRange = Random.Range(0, arrayRange);
                questionAsked = GameObject.Instantiate(categories.multiQuestions[randomRange], QuestionOrigin);
                int tempHashCode = categories.multiQuestions[randomRange].GetHashCode();
                categories.multiQuestions = cleanArray(categories.multiQuestions, tempHashCode);
            }
        }
        AssignButtonValues();
    }
    GameObject[] cleanArray(GameObject[]inputArray,int hashCode)
    {
        var arrayRange = inputArray.Length;
        GameObject[] tempArray = new GameObject[arrayRange - 1];
        for (int i = 0, j = 0; i < arrayRange; i++, j++)
        {
            if (!(inputArray[i].GetHashCode() == hashCode))
            {
                tempArray[j] = inputArray[i];
            }
            else
            {
                j--;
            }
        }
        return tempArray;
    }
    void AssignButtonValues()
    {
        //get the values from the question just Instantiated
        questionValue = questionAsked.GetComponent<QuestionValues>();
        answer = questionValue.Answer;
        var optionOne = questionValue.OptionOne;
        var optionTwo = questionValue.OptionTwo;
        //Get values of random 1,2, and 3 from a random range of 1-3
        assignRandomNumberToEachOption();
        //Assign the value of Button A
        if (random1 == 1)
        {
            AButton.text = answer;
        }
        else if (random1 == 2)
        {
            AButton.text = optionOne;
        }
        else if (random1 == 3)
        {
            AButton.text = optionTwo;
        }
        //Assign the value of Button B
        if (random2 == 1)
        {
            BButton.text = answer;
        }
        else if (random2 == 2)
        {
            BButton.text = optionOne;
        }
        else if (random2 == 3)
        {
            BButton.text = optionTwo;
        }
        //Assings the value of Button C
        if (random3 == 1)
        {
            CButton.text = answer;
        }
        else if (random3 == 2)
        {
            CButton.text = optionOne;
        }
        else if (random3 == 3)
        {
            CButton.text = optionTwo;
        }

    }
    void assignRandomNumberToEachOption()
    {
        random1 = Random.Range(1, 3);

        if (random1 == 1)
        {
            random2 = random1 + 1;
        }
        else if (random1 == 2)
        {
            random2 = random1 + 1;
        }
        else if (random1 == 3)
        {
            random2 = random1 - 2;
        }

        if (random2 == 2)
        {
            random3 = random2 + 1;
        }
        else if (random2 == 3)
        {
            random3 = random2 - 2;
        }
        else if (random2 == 1)
        {
            random3 = random2 + 1;
        }
    }
    //When choosing Button via click assign the playerAnswer Variable what value the Button Text represents.
    public void AnswerA()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        playerAnswer = AButton.text;
        CheckAnswer();
    }
    public void AnswerB()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        playerAnswer = BButton.text;
        CheckAnswer();
    }
    public void AnswerC()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        playerAnswer = CButton.text;
        CheckAnswer();
    }
    public void CheckAnswer()
    {
        //Check if the players answer is the same as the correct answer
        if (answer.Equals(playerAnswer))
        {
            answerCorrect = true;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Incorrect");
            answerIncorrect = true;
        }
    }
    public GameObject returnQuestionAsked()
    {
        return questionAsked;
    }
}
