using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Object = System.Object;

public class MarimbaHit : MonoBehaviour
{
    private  Collider hit1;
    private AudioSource sound;
    private AudioClip s;
    private double input;
    Puzzle p;
    
    void Start()
    {
        sound = GetComponent<AudioSource>();
        s = sound.GetComponent<AudioSource>().clip;
        hit1 = gameObject.GetComponent<Collider>();
        p = gameObject.transform.parent.GetComponent<Puzzle>();
    }
    
    void OnTriggerEnter(Collider hit)
    {
        if (!hit.gameObject.CompareTag("key"))
        {
            sound.PlayOneShot(s, (float)input); //set volume of note to input
            p.CollectData(gameObject);
            
        } 
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("drum"))
        {
            input = other.relativeVelocity.magnitude;
            input = input - (input/2);
            Debug.Log("nput" + input);
        }
    }

    private void Update()
    {
        OnTriggerEnter(hit1);
    }
    
}
