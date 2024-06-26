using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    //makes a slider range
    [SerializeField] [Range(0,2)] float movementFactor;
    // Start is called before the first frame update
    [SerializeField] float period =2f;
    void Start()
    {
        startingPosition= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period==Mathf.Epsilon){return;}
        float cycles = Time.time /period;
        const float tau = Mathf.PI *2;
        float rawSinWave=Mathf.Sin(cycles*tau);

        movementFactor = (rawSinWave+1f)/2f;

        Vector3 offset =movementVector*movementFactor;
        transform.position=startingPosition+offset;
    }
}
/*
https://obsproject.com/download
*/