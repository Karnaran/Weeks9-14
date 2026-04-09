using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayercontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpubliceaddawd 
    public LocalMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5;
    public AnimationCurve AnimationCurve;
    public Transform DuckTransform;
    public AudioSource AudioSource;
    public AudioClip handleCoins;
    public TrailRenderer trailRenderer;
    Vector3 min = new Vector3(0, 0, 0);
    Vector3 max = Vector3.one;
    Vector3 scaling;
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
        duckshift();
        // playerInput = Instantiate(playerInput);
        yield return null;
        AudioSource.PlayOneShot(handleCoins);
    }

    void duckshift()
    {

        float Duck = 0;
        {


            while (Duck < 1)
            {
                float t = Duck / 1;
                float curveValue = AnimationCurve.Evaluate(t);
                Duck += Time.deltaTime;
                scaling = (Vector3.Lerp(min, max, curveValue));
                DuckTransform.localScale = scaling;
            }

        }
    }

    public void Trailfollow(InputAction.CallbackContext context)

    {
        movementInput = context.ReadValue<Vector2>();
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
        trailRenderer.enabled = true;
        speed = 10;

    }
    IEnumerator speedTrail()

    {
        trail();
        yield return null;
    }

    void trail()
    {

        {
            {

                float Duck = 0;



                while (Duck < 1)
                {
                    trailRenderer.enabled = false;
                    speed = 5;
                }

            }
        }
    }
}



