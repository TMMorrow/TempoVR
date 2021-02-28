using UnityEngine;
using System;
using System.Collections;
using VRTK.Prefabs.Interactions.Interactables.Grab.Action;

public class ForceGrabNew : MonoBehaviour 
{
    //private float range = 10.0f;
 
    private Transform t;
    public Transform player;
    public Transform player1;
    public GameObject GrabbyBoy;
    
 
    private void Awake()
    {
        t = this.transform;
    }
 
    private void Update()
    {
        
        if (Distance() < .5 || Distance1() < .5)
        {
            GrabbyBoy.GetComponent<GrabInteractableFollowAction>().GrabOffset =
                GrabInteractableFollowAction.OffsetType.PrecisionPoint;
        }
        else
        {
            GrabbyBoy.GetComponent<GrabInteractableFollowAction>().GrabOffset =
                GrabInteractableFollowAction.OffsetType.OrientationHandle;
        }
    }
 
    
    private float Distance()
    {
        return Vector3.Distance(t.position, player.position);
    }
    
    private float Distance1()
    {
        return Vector3.Distance(t.position, player1.position);
    }
}