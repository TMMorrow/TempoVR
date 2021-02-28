using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BongoPuzzle : MonoBehaviour
{
    public Text wall;

    public BongoHit drum;
    

    public AudioSource source;
    public AudioClip sound;
    public int bpm;
    double sampleRate = 0.0F;
    double nextTick = 0.0F;
    bool ticked = false;
    private int yes = 0;
    public ParticleSystem bubbles;

    void Start()
    {
        drum.bang = false;
        wall.text = "Welcome. If you want to escape, match the tempo of the beat.";
        bpm = 60;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick + (60.0 / bpm);
    }

    void LateUpdate()
    {
        if (!ticked && nextTick >= AudioSettings.dspTime)
        {
            ticked = true;
            Puzzle1();
            Puzzle2();
            Puzzle3();
            
            BroadcastMessage("OnTick");
        }
    }


    void OnTick()
    {
        Debug.Log("Tick");
        source.PlayOneShot(sound);
    }

    void FixedUpdate()
    {
        double timePerTick = 60.0f / bpm;
        double dspTime = AudioSettings.dspTime;
        while (dspTime >= nextTick)
        {
            ticked = false;
            nextTick += timePerTick;
        }
    }

    void Puzzle1()
    {
        if (bpm == 60)
        {
           if (drum.bang)
           {
               yes++;
               if (yes == 4)
               {
                   wall.text = "Impressive. That tempo was 60 BPM. Now play the tempo of your heart";
                   yes = 0;
                   bubbles.Play();
                   bpm = 120;
               }
           }
           else
           { 
               yes = 0; } 
        }
        
    }

    void Puzzle2()
    {
        if (bpm == 120)
        {
            if (drum.bang)
            {
                yes++;
                if (yes == 4) 
                { 
                    wall.text = "That tempo was Allegro. Perhaps the most frequently used tempo marking at 120 BPM. Can you go faster?";
                    wall.fontSize = 13;
                    yes = 0;
                    bubbles.Play();
                    bpm = 160;
                }
            }
            else
            { 
                yes = 0;
            }
        }
    }

    void Puzzle3()
    {
        if (bpm == 160)
        {
            if (drum.bang)
            {
                yes++;
                if (yes == 4)
                {
                    wall.text = "That was 160 BPM. I'm impressed. You may leave";
                    wall.fontSize = 16;
                    yes = 0;
                    bubbles.Play();
                    bpm = 0;
                }
            }
            else
            {
                yes = 0;
            }
        }
    }
}