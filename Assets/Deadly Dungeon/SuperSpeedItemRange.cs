using JetBrains.Annotations;
using System.Threading;
using UnityEngine;

public class SuperSpeedItemRange : MonoBehaviour
{


    public GameObject PlayerObject;
    public Vector2 playerPosistion;
    public float pickUpRange;
    public KeyInput keyInput;
    public EventDrivenLara eventDrivenLara;
    public float timer = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosistion = PlayerObject.transform.position;
        if (transform.position.x <= pickUpRange + playerPosistion.x && transform.position.x >= playerPosistion.x - pickUpRange)
        {
            if (transform.position.y <= pickUpRange + playerPosistion.y)
            {
                if (transform.position.y >= playerPosistion.y - pickUpRange)
                {
                    //Debug.Log("hover" + playerPosistion);

                    if (keyInput.KeyInteraction)
                    {
                        print("pickedup");

                        SpeedPowerUp();  //calling the speed function here as it is contantly updating when interacted with

                    }
                }

                //overall, this whole block dictates the range of the item and the player and whether both of them are situated inbetween the barriers of the positive/negative X axis
                //and positive/negative Y axis
            }     
        }

        if (timer > 0)

        {
            timer -= Time.deltaTime; //the timer kicks off once the program is active, but runs out and stays dormant unless the player re-initaties it 
                                    //by interacting with the item which in turn will start the revere timer from 5 to 0 

        }
        else

        {
            eventDrivenLara.speed = 2; //Lara's speed returns to normal after 5 seconds from 10.
        }
    }

    public void SpeedPowerUp()
    {
        eventDrivenLara.speed = 10; 
        timer = 5;
        //setting up the basis to player's updated speed once picking up the powerup and the timer reduction
    }
}

