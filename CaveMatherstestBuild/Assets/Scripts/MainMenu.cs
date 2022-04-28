using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuText;
    public GameObject menuButton;
    public Light firelight;
    public bool turnDown, walk;
    public void PlayGame()
    {
        menuButton.SetActive(false);
        menuText.SetActive(false);
        turnDown = true;
        walk = true;
    }
    private void Update()
    {
        if (turnDown)
        {
            if (firelight.intensity > 0)
            {
                var increaseRate = 0.5f;
                firelight.intensity -= increaseRate * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
