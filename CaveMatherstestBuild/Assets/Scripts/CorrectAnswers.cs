using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswers : MonoBehaviour
{
    public GameObject [] answersCorrect;

    public int pointInArray;

    public GameObject GameBoard;
    GameBoardManager gameBoardManager;

    private void Start()
    {
        pointInArray = 0;
        gameBoardManager = GameBoard.GetComponent<GameBoardManager>();
    }

    public void saveAnswers()
    {
        if (gameBoardManager.answerCorrect == true && answersCorrect[pointInArray] == null)
        {
            GameObject temp = Instantiate(gameBoardManager.returnQuestionAsked());
            temp.transform.parent = gameObject.transform;
            answersCorrect[pointInArray] = temp;
            pointInArray++;
        }
    }

}
