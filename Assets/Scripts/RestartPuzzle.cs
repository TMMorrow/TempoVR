using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPuzzle : MonoBehaviour
{
    public GameObject puzzled;

    private void OnCollisionEnter(Collision other)
    {
        puzzled.GetComponent<Puzzle>().hits = "";
    }
    
}
