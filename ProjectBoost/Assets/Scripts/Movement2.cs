using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    //parameters
    //cache
    //state
    [SerializeField] float mainThrust=1000;
    [SerializeField] float rotationThrust=300;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //  Debug.Log("Pressed SPACE - Thrusting");
            //rb.AddRelativeForce(0,1,0);
            //short hand for (0,1,0)
            rb.freezeRotation=true;
            rb.AddRelativeForce(Vector3.up* mainThrust*Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                //not very practical because audioSource.Play() dont have parameters if we want to play multiple clips, it is not suited
                //audioSource.Play();
                audioSource.PlayOneShot(mainEngine);
            }
            
            rb.freezeRotation=false;
        }
        else
        {
            audioSource.Stop();
        }
    }
    void ProcessRotation(){
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationThrust);
        }
        }

    private void ApplyRotation(float rotationThisFrame)
    {
        //Debug.Log("Rotating Left");
        //rb.AddRelativeForce(Vector3.left* mainThrust*Time.deltaTime);
        rb.freezeRotation=true;//freezing rotation of physics so we can rotate manually
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false;
    }
}
/*
gitlab
sourcetree
------------

get the free auido from freesound.org
add it to auidio sourse of the specific object

audacityteam.org audacity tool for making your own audio files
*/