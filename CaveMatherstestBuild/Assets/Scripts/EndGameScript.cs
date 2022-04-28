using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    public Light RoomLight1;
    float deltaTime;
    public GameObject UI;


    // Start is called before the first frame update
    void Start()
    {
        RoomLight1.intensity = 0;
        Camera.main.backgroundColor = Color.black;
        UI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Woods");
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += 0.1f * Time.deltaTime;

        if(RoomLight1.intensity >=1)
        {
            if (transform.position.x < 14.5f)
            {
                transform.position += Vector3.right * 1 * Time.deltaTime;
            }
            else
            {
                UI.SetActive(true);
            }
        }
        else
        {
            RoomLight1.intensity += 0.2f * Time.deltaTime;
        }
        Camera.main.backgroundColor = Color.Lerp(Color.black, Color.white, deltaTime);
    }
    public void PlayAgain()
    {
        Destroy(GameObject.Find("Answers correct"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
