using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DrumHit : MonoBehaviour
{
    public Collider hit1;
    public AudioSource sound;
    private AudioClip s;
    private float input;
    private bool allow;
    public float hitpos;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        s = sound.GetComponent<AudioSource>().clip;
    }
    
    void OnTriggerEnter(Collider hit)
    {
        if (!hit.gameObject.CompareTag("drum") && allow)
        {
            sound.PlayOneShot(s, input);
            allow = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("drum"))
        {
            input = other.relativeVelocity.magnitude;
            foreach (ContactPoint contact in other.contacts)
            {
                if (contact.point.y >= hitpos)
                {
                    allow = true;
                }
                print(contact.otherCollider.name + " hit " + contact.thisCollider.name + " at " + contact.point);
                
            }
            //Debug.Log("nput" + input);
        }
    }
    

    private void Update()
    {
        OnTriggerEnter(hit1);
    }
    
}
