using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public GameObject Menu;
    MainMenu mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        mainMenu = Menu.GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mainMenu.walk == true)
        {
            transform.position += new Vector3(0, 0, 1) * 1 * Time.deltaTime;
        }
    }
}
