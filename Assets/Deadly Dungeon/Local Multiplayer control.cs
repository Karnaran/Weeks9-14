using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayercontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpubliceaddawd 
    public LocalMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        StartCoroutine(Attacking());
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Attacking!");
            manager.PlayerAttacking(playerInput);
        }
    }

    IEnumerator Attacking()

    {

        playerInput = Instantiate(playerInput);
        yield return null;  
    }
}
