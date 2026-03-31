using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Knight : MonoBehaviour


{
    public AudioSource SFX;
    public CinemachineImpulseSource impulseSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void footstep ()

    {

        Debug.Log("Step!");
        SFX.Play();
        impulseSource.GenerateImpulse();
    }

    public void Jump()

    {
       
    }

}
