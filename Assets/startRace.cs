using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startRace : MonoBehaviour
{
    private bool runOnce = false;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="ship"&&runOnce==false)
        {
            manager.instance.counter++;
            other.GetComponent<testAgent>().waiting = true;
            other.GetComponent<testAgent>().agent.speed = 0;
            runOnce = true;
        }
    }
}
