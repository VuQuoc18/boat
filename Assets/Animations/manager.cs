using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject finishedTxt;

    public static manager instance;
    public bool startRealRace = false;
    public int counter = 0;


    private void Awake()
    {
        instance = this;
    }


    public int pointsReached = 0;

    private void Update()
    {
        if(counter==6)
        {
            startRealRace = true;
        }
    }
    public void gameFinished()
    {
        if(finishedTxt.activeInHierarchy==false)
        {
            finishedTxt.SetActive(true);
        }
    }
}
