using UnityEngine;
using System.Collections;
public class NewMonoBehaviourScript : MonoBehaviour
{


    public GameObject PlayerObject;
    public Vector2 playerPosistion;
    public float pickUpRange;
    public KeyInput keyInput;
    public EventDrivenLara eventDrivenLara;
    public Transform ShieldManfestation;
    public GameObject shield;
    public float timer = 5;
    public GameObject currentShield;
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
                            ShieldTimerDuration(); //calling the duration function here as it is contantly updating when interacted with

                            if (currentShield == null)

                            {
                                ShieldpowerUp(); //making currentShild equal to null for it to be destroyed.  
                            }
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
                Destroy(currentShield); //despawns the shield object once the timer hits 0
            }
        }
    }

    public void ShieldpowerUp()

    {
        StartCoroutine(ShieldProtection()); //calling the ShieldProtection function here for it connect to the couroutine and merge with it


    }



    IEnumerator ShieldProtection()
    {
        currentShield = Instantiate(shield, ShieldManfestation);
        yield return null; //to return the  statement because this function has a return type.

    }

    public void ShieldTimerDuration()
    {

        timer = 5;         //setting up the basis to player's shield once picking up the powerup and the timer reduction that starts off rigth away


    }
}
