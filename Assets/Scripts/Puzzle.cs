using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Object = System.Object;

public class Puzzle : MonoBehaviour
{
    private List<GameObject> keys = new List<GameObject>();
    public String hits;
    public ParticleSystem bubbles;
    void Start()
    {
        bubbles.Stop();
    }

    void Debugg()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            /*foreach (var i in keys)
            {
                string s = Regex.Replace(i.name, @"[\d-]", string.Empty); //NolDorin, Stack Overflow
                
                Debug.Log(s);
            }*/
            Debug.Log(keys);
            Debug.Log(hits);
            //bubbles.Play();
        }
    }
    
    
    void Update()
    {
        Debugg();
        CheckWin();
    }
    
    public void CollectData(GameObject g)
    {
        keys.Add(g);
        string s = Regex.Replace(g.name, @"[\d-]", string.Empty); //NolDorin, Stack Overflow
        hits = hits + s;
        
    }

    void CheckWin()
    {

        if (hits != null)
        {
            if (hits.Equals("CDEFGABC"))
            {
                Debug.Log("Win!");
                bubbles.Play();
            }
        }
    }
}
