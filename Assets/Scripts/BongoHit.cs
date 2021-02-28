using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BongoHit : MonoBehaviour
{
    public Collider hit1;
    public Collider hit2;
    public AudioSource sound;
    public AudioClip clip;
    private float input;
    public bool bang;
    public int hitCount;


    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if (!hit.gameObject.CompareTag("drum"))
        {
                sound.Play();
                bang = true;
                //Debug.Log(bang);
        }

        if (bang)
        {
            hitCount++;
            //Debug.Log(hitCount);
        }
    }

    
    void OnTriggerExit(Collider hit)
    {
        if (!hit.gameObject.CompareTag("drum"))
        {
            bang = false;
            //Debug.Log("LEAVE");
            //Debug.Log(bang);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("drum"))
        {
            input = other.relativeVelocity.magnitude;
            //Debug.Log("nput" + input);
        }
    }
}
    



    

