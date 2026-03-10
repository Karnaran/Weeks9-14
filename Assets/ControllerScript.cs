using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerScript : MonoBehaviour


{
    public float speed = 5;
    public Vector2 movement;
    public AudioSource SFX;
    public AudioSource TFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3)movement * speed * Time.deltaTime; 

        transform.position = movement;
    }

    public void OnMove(InputAction.CallbackContext context)

    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
        Debug.Log("Attack" + context.phase);
        if (context.performed == true)
        {
            SFX.Play(); 
        }

    }

    public void Onpoint(InputAction.CallbackContext context)

    {
        //the same as Mouse.current.posistion.ReadValue();
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());

    }

}
