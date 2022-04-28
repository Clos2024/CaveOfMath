using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTracker : MonoBehaviour
{
    public int roomsTraveled;
    public Text roomText;

    // Updates the UI text with how many rooms the player has traveled to
    void Update()
    {
        roomText.text = "ROOMS : " + roomsTraveled;
    }
}
