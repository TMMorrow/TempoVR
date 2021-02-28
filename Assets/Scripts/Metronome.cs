using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public Material MetLight;
    public int bpm;
    public AudioSource source;
    public AudioClip sound;
    private bool on = false;
    public Collider hit1;
    private bool ready = true;

    void Debugg()
    {
//        Debug.Log("BPM Return:" + (float)60.0 / bpm);
    }
    
    private IEnumerator LightFlash(float waitTime)
    {
        while (on)
        {
            Debug.Log(Time.time);
            //MetLight.SetColor("_Color", Color.black);
            yield return new WaitForSecondsRealtime((float) 60.0 / waitTime);
            StartCoroutine(ColorChange());
            source.PlayOneShot(sound);
        }
    }

    private IEnumerator ColorChange()
    {
        MetLight.SetColor("_Color", Color.red);
        yield return new WaitForSecondsRealtime((float)0.000000000000000000000000000000000001);
        MetLight.SetColor("_Color", Color.black);
    }

    private void TurnOn()
    {
        if (on == false)
        {
            on = true;
            //Debug.Log(on);
            StartCoroutine(LightFlash(bpm));
        }
        else
        {
            on = false;
            //Debug.Log(on);
            StopCoroutine(LightFlash(bpm));
        }
    }
    
    IEnumerator OnTriggerEnter(Collider hit)
    {
        if (!hit.gameObject.CompareTag("met") && ready)
        {
            ready = false;
            TurnOn();
            yield return new WaitForSecondsRealtime(2);
            ready = true;
        } 
    }
    
    void Update()
    {
        Debugg();
        StartCoroutine(OnTriggerEnter(hit1));
    }
}
