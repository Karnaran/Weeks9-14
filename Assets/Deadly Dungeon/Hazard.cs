using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class Hazard : MonoBehaviour
{
    public List<SpriteRenderer> hazardSRs;
    public bool isInHazard = false;
    public UnityEvent OnEnterHazard;
    public UnityEvent OnExitHazard;
    bool wasInHazardLastFrame;
    public float timer;
    public float hurttimer;
    public float LoseHealth;
    public float resetTimer;
    public bool ConditionsHazard;
    public CoroutineShieldItemRange CoroutineShieldItemRange;
    public EventDrivenLara EventDrivenLara;
    void Update()
    {
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
                //just entered hazard
                OnEnterHazard.Invoke();

                isInHazard = true;
                //as soon as we're in one we need to skip out of the loop so we don't say
                //oh, no we're not in this water and ignore the previous one we are in...
                StayingStill();
                return;
            } 

        }
        else
        {
            if (wasInHazardLastFrame)
            {
                OnExitHazard.Invoke();
                //still in the hazard

                isInHazard = false;
                exitpoison();
                return;
            }
            else
            {
                isInHazard = false;

                //as soon as we're in one we need to skip out of the loop so we don't say
                //oh, no we're not in this water and ignore the previous one we are in...

            }

            //overall for this block, i made it so the poison sprites track the player's footprints and base off of it act accordingly once the player enters and leaves. 
            //Orignally, it was taking the two poison sprites into account but now it takes either one depeneding on which the player interacts with

        }
        //have to wait to the end of the loop to see if we've left the hazard though ;-)
        //we have to check all the waters, not just stop at the first false because
        //there's plenty we won't be in even if we are still swimming...
        if (ConditionsHazard == true)
        {
            if (timer <= 0)

            {
                LoseHealth = 2;                   //if timer is less than equal to zero, +2 damage is added as the player lose hp by 2 if they linger more than 5 seconds in the poison
                timer = resetTimer;                 
                EventDrivenLara.TakeDamage(+2);
            }
            else

            {
                timer -= Time.deltaTime;

            }
        }
    }

    public void StayingStill()

    {
        timer = 5;
        Debug.Log("entered");
        ConditionsHazard = true; //conditions are met for the timer to initate before the player starts losing health
    }

    public void exitpoison()

    {
        Debug.Log("exited");
        ConditionsHazard = false; //conditions are dismissed once the player leaves the poison which inflicts the else and deltatime
    }
}

