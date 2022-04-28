using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public int currScore;
    public Text scoreText;

    // Updates the UI text with how many rooms the player has traveled to
    void Update()
    {
        scoreText.text = "SCORE : " + currScore;
    }
}
