using System.Collections;
using Unity.Cinemachine;
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
   public  Vector3 min = new Vector3(0, 0, 0);
   public Vector3 max = Vector3.one;
    Vector3 scaling;
    public CinemachineImpulseSource impulseSource;
    public ParticleSystem particles;
    public SpriteRenderer spriteRenderer;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
        particles.Emit(10);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Attacking!");
            manager.PlayerAttacking(playerInput);
            StartCoroutine(duckshift());

        }
    }


    public void playerStriked()

    {
        transform.rotation = Quaternion.identity;   
        spriteRenderer.color = Color.red;
        impulseSource.GenerateImpulse();
       
    }


    IEnumerator duckshift()
    {

        float Duck = 0;



        while (Duck < 1)
        {
            float t = Duck / 1;
            float curveValue = AnimationCurve.Evaluate(t);
            Duck += Time.deltaTime;
            scaling = (Vector3.Lerp(min, max, curveValue));
            DuckTransform.localScale = scaling;
            yield return null;
        }
        AudioSource.PlayOneShot(handleCoins);

    }

    public void Trailfollow(InputAction.CallbackContext context)

    {
        if (context.phase == InputActionPhase.Performed)
        {
            trailRenderer.enabled = true;
            speed = 10;
            StartCoroutine(trail());

        }
    }


    IEnumerator trail()
    {




        float Duck = 0;



        while (Duck < 1)
        {
            Duck += Time.deltaTime;
            yield return null;

        }

        trailRenderer.enabled = false;
        speed = 5;
        print(Duck);


    }
}



