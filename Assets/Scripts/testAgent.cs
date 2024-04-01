using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class testAgent : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform target, target2, target3, target4, target5;
    public Transform target6, target7, target8, target9, target10;

    public int speedobj = 35;
    private float changeSpeedRandom = 9;
    private float currentTimer = 0;
    public int destinationCounter = 0;
    private int lapCounter = 0;

    public bool slowBoat = false;
    public bool hasCompletedPath1 = false;
    public bool notallowedToChangeSpeed = false;
    public bool isFastBoat=false;
    public manager manager;
  
    void Start()
    {
        agent.speed = speedobj;
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (notallowedToChangeSpeed == false)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= changeSpeedRandom)
            {
                speedobj = Random.Range(80, 90);
                agent.speed = speedobj;
                currentTimer = 0;
            }
        }

        if (destinationCounter == 4 && lapCounter == 5)
        {
            if (agent.remainingDistance < 5 && !agent.pathPending)
            {

                if (lapCounter == 5)
                {
                    Invoke("stopRace", 3);
                   
                }
            }
        }
        else
        {
            if (agent.remainingDistance < 25 && !agent.pathPending)
            {
                changeDestination();

            }
        }
    }

    public void changeDestination()
    {
        if (agent.enabled == true)
        {
            if (agent.pathPending == false)
            {
                if (destinationCounter == 0)
                {
                    agent.SetDestination(target.transform.position);
                   
                    destinationCounter++;
                }
                else if (destinationCounter == 1)
                {
                    agent.SetDestination(target2.transform.position);
                    destinationCounter++;
                }
                else if (destinationCounter == 2)
                {
                    agent.SetDestination(target3.transform.position);
                    destinationCounter++;
                }
                else if (destinationCounter == 3)
                {
                    if (slowBoat == true&&hasCompletedPath1==false)
                    {
                        agent.speed = 15;
                        notallowedToChangeSpeed = true;
                        Invoke("resetSpeed", 4);
                        if (isFastBoat == true)
                        {
                            Invoke("resetAllowToChange", 6);
                        }
                        else
                        {
                            Invoke("resetAllowToChange", 8);
                        }
                    }
                    else if (slowBoat == false)
                    {

                    }
                    agent.SetDestination(target4.transform.position);
                    lapCounter++;
                    destinationCounter++;
                    //if (lapCounter == 3)
                    //{
                    //    Invoke("stopRace", 8);
                    //    //stopRace();
                    //}

                }
                else if (destinationCounter == 4)
                {
                    
                    agent.SetDestination(target5.transform.position);
                    hasCompletedPath1 = true;
                    destinationCounter++;

                }
                else if(destinationCounter==5)
                {
                    agent.SetDestination(target6.transform.position);
                  
                    destinationCounter++;
                }
                else if (destinationCounter == 6)
                {
                    agent.SetDestination(target7.transform.position);

                    destinationCounter++;
                }
                else if (destinationCounter == 7)
                {
                    agent.SetDestination(target8.transform.position);

                    destinationCounter++;
                }
                else if (destinationCounter == 8)
                {
                    agent.SetDestination(target9.transform.position);

                    destinationCounter++;
                }
                else if (destinationCounter == 9)
                {
                    agent.SetDestination(target10.transform.position);

                    destinationCounter = 4;
                    lapCounter++;
                }
            }
        }
        
    }
    public void resetAllowToChange()
    {
        notallowedToChangeSpeed = false;
    }
    public void resetSpeed()
    {
        
        agent.speed = 30;
        if(isFastBoat==true)
        {
            agent.speed = 80;
        }

    }
    public void stopRace()
    {
        if (agent.enabled == true)
        { 
            transform.GetComponent<Rigidbody>().isKinematic = true;
            agent.enabled = false;
            transform.GetComponent<testAgent>().enabled = false;
            Invoke("stopRace2", 4);
        }

    }
    public void stopRace2()
    {
        manager.finishedTxt.SetActive(true);
    }
}
