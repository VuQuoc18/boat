using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableSecondCame : MonoBehaviour
{
    public GameObject firstCam, secondCam;


    public void disableCamObj()
    {
        firstCam.SetActive(false);
        secondCam.SetActive(true);

    }
}
