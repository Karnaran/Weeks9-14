using UnityEngine;

public class SuperSpeedItemRange : MonoBehaviour
{


    public GameObject PlayerObject;
    public Vector2 playerPosistion;
    public float pickUpRange;
    public KeyInput keyInput;

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

                    }
                }

                //overall, this whole block dictates the range of the item and the player and whether both of them are situated inbetween the barriers of the positive/negative X axis
                //and positive/negative Y axis
            }


        }
    }
}

