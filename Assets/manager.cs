using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject finishedTxt;


    public void gameFinished()
    {
        if(finishedTxt.activeInHierarchy==false)
        {
            finishedTxt.SetActive(true);
        }
    }
}
