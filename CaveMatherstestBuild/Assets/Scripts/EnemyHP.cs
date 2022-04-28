using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    Slider EnemyHealthBar;
    GameObject healthBar;
    CreatureBehavior creatureBehavior;
    RoomTracker roomTracker;
    public bool death;

    // Start is called before the first frame update
    void Start()
    {
        creatureBehavior = GetComponent<CreatureBehavior>();
        healthBar = GameObject.Find("Canvas/EnemyHealthBarHolder/EnemyHealthBar");
        roomTracker = GameObject.Find("Canvas/Rooms").GetComponent<RoomTracker>();
        EnemyHealthBar = healthBar.GetComponent<Slider>();
        if (roomTracker.roomsTraveled <= 1)
        {
            MaxHealth = 6.0f;
        }
        else if (roomTracker.roomsTraveled > 1 && roomTracker.roomsTraveled < 4)
        {
            MaxHealth = 8.0f;
        }
        else
        {
            MaxHealth = 16.0f;
        }
        CurrentHealth = MaxHealth;
        EnemyHealthBar.value = CalcHealth();
    }

    // Update is called once per frame
    void Update()
    {

        EnemyHealthBar.value = CalcHealth();

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage()
    {
        CurrentHealth -= 2f;
        EnemyHealthBar.value = CalcHealth();
        
        if (creatureBehavior.spider)
        {
            FindObjectOfType<AudioManager>().Play("Spider");
        }
        else if (creatureBehavior.wolf)
        {
            FindObjectOfType<AudioManager>().Play("WolfBark");
        }
        else if (creatureBehavior.rat)
        {
            FindObjectOfType<AudioManager>().Play("Rat");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Spider");
        }
        FindObjectOfType<AudioManager>().Play("Hit");
    }

    float CalcHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    void Death()
    {
        death = true;
    }
}
