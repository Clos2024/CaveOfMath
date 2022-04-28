using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject minionOne, minionTwo, minionThree, BossOne, BossTwo, BossThree,CreatureOrigin;
    GameObject CreatureInField;
    PlayerMovement playerMovement;
    int roomsDonePathOne, roomsDonePathTwo, roomsDonePathThree;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        roomsDonePathOne = playerMovement.pathOneTaken;
        roomsDonePathTwo = playerMovement.pathTwoTaken;
        roomsDonePathThree = playerMovement.pathThreeTaken;

        if (CreatureInField == null && playerMovement.playerState == States.Enter)
        {
            if (playerMovement.playerMathLevel <=3 && roomsDonePathOne <=3)
            {
                CreatureInField = GameObject.Instantiate(minionOne, CreatureOrigin.transform);
                var creatureBehavior = CreatureInField.GetComponent<CreatureBehavior>();
                creatureBehavior.spider = true;
            }
            else if(playerMovement.playerMathLevel <= 3 && roomsDonePathOne > 3)
            {
                CreatureInField = GameObject.Instantiate(BossOne, CreatureOrigin.transform);
                var creatureBehavior = CreatureInField.GetComponent<CreatureBehavior>();
                creatureBehavior.BossOne = true;
            }
            else if (playerMovement.playerMathLevel <= 6 && playerMovement.playerMathLevel >=4 && roomsDonePathTwo <= 3)
            {
                CreatureInField = GameObject.Instantiate(minionTwo, CreatureOrigin.transform);
                var creatureBehavior = CreatureInField.GetComponent<CreatureBehavior>();
                creatureBehavior.wolf = true;
            }
            else if (playerMovement.playerMathLevel <= 6 && playerMovement.playerMathLevel >= 4 && roomsDonePathTwo > 3)
            {
                CreatureInField = GameObject.Instantiate(BossTwo, CreatureOrigin.transform);
                var creatureBehavior = CreatureInField.GetComponent<CreatureBehavior>();
                creatureBehavior.BossTwo = true;
            }
            if (playerMovement.playerMathLevel <= 8 && playerMovement.playerMathLevel >= 7 && roomsDonePathThree <= 3)
            {
                CreatureInField = GameObject.Instantiate(minionThree, CreatureOrigin.transform);
                var creatureBehavior = CreatureInField.GetComponent<CreatureBehavior>();
                creatureBehavior.rat = true;
            }
            else if (playerMovement.playerMathLevel <= 8 && playerMovement.playerMathLevel >= 7 && roomsDonePathThree > 3)
            {
                CreatureInField = GameObject.Instantiate(BossThree, CreatureOrigin.transform);
                var creatureBehavior = CreatureInField.GetComponent<CreatureBehavior>();
                creatureBehavior.BossThree = true;
            }
        }
    }
}
