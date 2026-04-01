using UnityEngine;

public class HealthItemRange : MonoBehaviour
{
    public GameObject PlayerObject;
    public Vector2 playerPosistion;
    public float pickUpRange;
    public KeyInput keyInput;
    public ModularSliderVisuals ModularSliderVisuals;
    public EventDrivenLara eventDrivenLara;
    
    public float timer = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            playerPosistion = PlayerObject.transform.position;
            if (transform.position.x <= pickUpRange + playerPosistion.x && transform.position.x >= playerPosistion.x - pickUpRange)
            {
                if (transform.position.y <= pickUpRange + playerPosistion.y)
                {
                    if (transform.position.y >= playerPosistion.y - pickUpRange)
                    {
                      
                        //Debug.Log("hover" + playerPosistion);
                        //overall, this code block dictates the range of the item and the player and whether both of them are situated inbetween the barriers of the positive/negative X axis
                        //and positive/negative Y axis

                        if (keyInput.KeyInteraction)
                        {
                            print("pickedup");
                            HealthTimerDuration();
                            ModularSliderVisuals.UpdateSlider(10);
                        }
                    }

                }
            }

            if (timer > 0)

            {
                timer -= Time.deltaTime; //the timer kicks off once the program is active, but runs out and stays dormant unless the player re-initaties it 
                                         //by interacting with the item which in turn will start the revere timer from 5 to 0 

            }
            else

            {
               
            }

        }
    }


    public void HealthTimerDuration()
    {

        timer = 5;         //setting up the basis to player's shield once picking up the powerup and the timer reduction that starts off rigth away


    }
}



