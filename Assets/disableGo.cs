using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableGo : MonoBehaviour
{

    public GameObject obj;
   public void unstop()
    {
        obj.SetActive(false);
    }
}
