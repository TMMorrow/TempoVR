using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MarimbaSetup : MonoBehaviour
{
    private AudioSource source;
    public AudioClip s;
    public int dist;
    
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = s;
        SetPitch();
    }

    void SetPitch()
    {
        for (int i = 0; i < dist; i++)
        { 
            source.pitch = source.pitch * (float) 1.05946;
        }
    }
}
