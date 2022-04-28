using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider HealthBar;

    GameBoardManager gameBoardManager;
    PlayerMovement player;
    public GameObject GameBoard;

    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        gameBoardManager = GameBoard.GetComponent<GameBoardManager>();
        player = GetComponent<PlayerMovement>();

        MaxHealth = 6f;
        //Reset health to full on game load
        CurrentHealth = MaxHealth;

        HealthBar.value = CalcHealth();

        FindObjectOfType<AudioManager>().Play("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = CalcHealth();

        if(CurrentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage()
    {
        CurrentHealth -= 2f;
        HealthBar.value = CalcHealth();
    }

    float CalcHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    void Death()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
        death = true;
    }
}
