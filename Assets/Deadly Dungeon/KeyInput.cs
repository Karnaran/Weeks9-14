using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInput : MonoBehaviour
{

    public InputAction InteractionInput;
    public bool KeyInteraction; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractionInput = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPickupCollectedEvent(InputAction.CallbackContext interAct )

    {
        Debug.Log( " pickup " + interAct.phase );

        if (interAct.phase == InputActionPhase.Started)

        {
            //print("pressed");
            KeyInteraction = true;
        }

        else if (interAct.phase == InputActionPhase.Canceled)

        {
            //print("release");
            KeyInteraction = false;
        }
    }

}
