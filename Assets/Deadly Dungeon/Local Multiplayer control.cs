using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
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
    public Vector3 min = new Vector3(0, 0, 0);
    public Vector3 max = Vector3.one;
    Vector3 scaling;
    public CinemachineImpulseSource impulseSource;
    public ParticleSystem particles;
    public SpriteRenderer spriteRenderer;
    public float rotationSpeed = 100;
    public float HP = 5;
    public bool isInHazard = false;
    public bool isDead;
    bool wasInHazardLastFrame;
    public bool ConditionsHazard = true;
    public List<SpriteRenderer> hazardSRs;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;

        wasInHazardLastFrame = isInHazard;
        isInHazard = false;

        foreach (SpriteRenderer sr in hazardSRs)
        {
            if (sr.bounds.Contains(transform.position))
            {
                isInHazard = true;
            }
        }

        if (isInHazard)
        {
            if (wasInHazardLastFrame)
            {
                isInHazard = true;
            }
            else
            {

                playerStriked();

                isInHazard = true;


                return;
            }

        }
        else
        {

            isInHazard = false;

        }


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
    public void outofRange()

    {
        ConditionsHazard = true;
    }


    public void playerStriked()

       

    {

        {
            spriteRenderer.color = Color.red;
            impulseSource.GenerateImpulse();
            StartCoroutine(rotate360());
            HP -= 1;
            OnParticleTrigger();
        }
      


        if (HP <= 0)

        {
            isDead = true;
        }
    }


    void OnParticleTrigger()
    {
        particles.Emit(10);
    }


    IEnumerator rotate360()

    {
        float Duck = 0;

        while (Duck < 360)
        {
            Vector3 newRotation = transform.eulerAngles;
            newRotation.z += rotationSpeed * Time.deltaTime;
            Duck += rotationSpeed * Time.deltaTime;
            transform.eulerAngles = newRotation;

            yield return null;
        }
        spriteRenderer.color = Color.white;

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

    public void Healing()

    {

        HP = 5;
        isDead = false; 
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



