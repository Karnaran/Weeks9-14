using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PickupItem : MonoBehaviour
{

    public GameObject sueperspeedItem;
    public Vector2 superspeedItemposistion;
    public Vector2 playerPosistion;
    public int pickUpRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosistion = transform.position;
        if (playerPosistion.x <= pickUpRange + superspeedItemposistion.x)
        {
            if (playerPosistion.x >= pickUpRange + superspeedItemposistion.x)
            {

            }
            if (playerPosistion.y <= pickUpRange + superspeedItemposistion.y)
            {
                if (playerPosistion.y >= pickUpRange + superspeedItemposistion.y)
                {

                }
                Debug.Log("hover" + playerPosistion);
            }
        }

        //public void ()

        //{


        //}

    }
}