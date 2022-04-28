using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    CorrectAnswers correctAnswers;
    // Start is called before the first frame update
    private void Awake()
    {
        correctAnswers = GameObject.Find("Answers correct").GetComponent<CorrectAnswers>();
        DontDestroyOnLoad(gameObject);

        var size = correctAnswers.answersCorrect.Length;
        for (int i = 0; i < size; i++)
        {
            if (correctAnswers.answersCorrect[i] != null)
            {
                DontDestroyOnLoad(correctAnswers.answersCorrect[i]);
            }
        }
    }
}
