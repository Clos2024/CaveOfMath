using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPropManager : MonoBehaviour
{
    public GameObject propLayoutOne, propLayoutTwo, propLayoutThree, propLayoutFour, propLayoutFive, propLayoutSix, propLayoutSeven, propLayoutEight, propLayoutNine, propLayoutTen, propBossRoom, firstRoom;
    GameObject player;
    PlayerMovement playerMovement;
    public int pathOne, pathTwo, pathThree;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        pathOne = 0;
        pathTwo = 0;
        pathThree = 0;
        firstRoom.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z >= 0.9f)
        {
            propLayoutOne.SetActive(false);

            if(playerMovement.pathOne)
            {
                if(pathOne == 1)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(true);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                if(pathOne == 2)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(true);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                if (pathOne == 3)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(true);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                else if (pathOne == 4)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                    propBossRoom.SetActive(true);
                }
            }
            else if (playerMovement.pathTwo)
            {
                if (pathTwo == 1)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(true);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                if (pathTwo == 2)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(true);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                if (pathTwo == 3)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(true);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                else if (pathTwo == 4)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                    propBossRoom.SetActive(true);
                }
            }
            else if(playerMovement.pathThree)
            {
                if(pathThree == 1)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(true);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                }
                else if(pathThree == 2)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(true);
                    propLayoutTen.SetActive(false);
                }
                else if(pathThree == 3)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(true);
                }
                else if (pathThree == 4)
                {
                    propLayoutOne.SetActive(false);
                    propLayoutTwo.SetActive(false);
                    propLayoutThree.SetActive(false);
                    propLayoutFour.SetActive(false);
                    propLayoutFive.SetActive(false);
                    propLayoutSix.SetActive(false);
                    propLayoutSeven.SetActive(false);
                    propLayoutEight.SetActive(false);
                    propLayoutNine.SetActive(false);
                    propLayoutTen.SetActive(false);
                    propBossRoom.SetActive(true);
                }
            }
        }
    }
}
