using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tick : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;
    public double bpm;
   
       double nextTick = 0.0F; // The next tick in dspTime
       double sampleRate = 0.0F; 
       bool ticked = false;
   
       void Start()
       {
           bpm = 60;
           double startTick = AudioSettings.dspTime;
           sampleRate = AudioSettings.outputSampleRate;
   
           nextTick = startTick + (60.0 / bpm);
       }
   
       void LateUpdate() {
           if ( !ticked && nextTick >= AudioSettings.dspTime ) {
               ticked = true;
               BroadcastMessage( "OnTick" );
           }
       }
   
       
       void OnTick() {
           Debug.Log( "Tick" );
           source.PlayOneShot(sound);
       }
   
       void FixedUpdate() {
           double timePerTick = 60.0f / bpm;
           double dspTime = AudioSettings.dspTime;
   
           while ( dspTime >= nextTick ) {
               ticked = false;
               nextTick += timePerTick;
           }
   
       }
   }