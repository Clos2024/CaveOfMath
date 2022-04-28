using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestionsRight : MonoBehaviour
{
    CorrectAnswers correctAnswers;
    GameObject questionDisplayed;
    Transform questionOrigin;
    int pointInArray, lengthOfArray;
    public Text answerText;
    // Start is called before the first frame update
    void Awake()
    {
        correctAnswers = GameObject.Find("Answers correct").GetComponent<CorrectAnswers>();
        questionOrigin = GameObject.Find("QuestionOrigin").GetComponent<Transform>();
    }
    private void Update()
    {
        if (pointInArray > correctAnswers.answersCorrect.Length)
        {
            pointInArray = 0;
        }
    }
    private void Start()
    {
        pointInArray = 0;
        questionDisplayed = GameObject.Instantiate(correctAnswers.answersCorrect[pointInArray], questionOrigin);
        questionDisplayed.transform.position = questionOrigin.transform.position;
        var answer = questionDisplayed.GetComponent<QuestionValues>().Answer;
        answerText.text = "Answers: " + answer;
        lengthOfArray = correctAnswers.answersCorrect.Length;

    }
    public void NextQuestion()
    {
        if (pointInArray < lengthOfArray)
        {
            questionDisplayed = null;
            pointInArray++;
            DisplayQuestion();
        }
    }
    public void BackQuestion()
    {
        if (pointInArray > 0)
        {
            questionDisplayed = null;
            pointInArray--;
            DisplayQuestion();
        }
    }
    void DisplayQuestion()
    {
        if (questionDisplayed == null)
        {
            questionDisplayed = GameObject.Instantiate(correctAnswers.answersCorrect[pointInArray], questionOrigin);
            questionDisplayed.transform.position = questionOrigin.transform.position;
            var answer = questionDisplayed.GetComponent<QuestionValues>().Answer;
            answerText.text = "Answers: " + answer;
        }
    }
}
