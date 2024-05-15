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
    public Transform target6, target7, target8, target9, target10, target11, target12;

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
    public bool divertBoat = false;
    public bool disqualify = false;
    public float tiltAngle = 30f; // Maximum tilt angle
    public float tiltSpeed = 1f; // Tilt speed
    public GameObject driver;
    public GameObject clock;
    public bool waiting = false;
    private bool doOnce = false;
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
                speedobj = Random.Range(80, 81);
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
            if (agent.remainingDistance < 30 && !agent.pathPending)
            {
                changeDestination();

            }
        }

        if(disqualify==true)
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            agent.enabled = false;
            transform.GetComponent<Animator>().enabled = true;
            transform.GetComponent<Animator>().Play("tiltBoat");

            // Move the boat forward
            transform.Translate(Vector3.forward * 40* Time.deltaTime);
            Invoke("throwDriver", 1);
           
            Invoke("stopDisqualify", 3);
        }

        if(waiting==true)
        {
            if(manager.startRealRace==true)
            {
                //agent.speed = 80;
            }
        }
    }

    public void throwDriver()
    {
        driver.transform.parent = null;
    }
    public void stopDisqualify()
    {
        disqualify = false;
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
                    if (isFastBoat == true)
                    {
                        agent.acceleration = 32;
                    }

                }
                else if (destinationCounter == 2)
                {
                    agent.SetDestination(target3.transform.position);
                    destinationCounter++;


                }
                else if (destinationCounter == 3)
                {
                    if (slowBoat == true && hasCompletedPath1 == false && isFastBoat == false)
                    {
                        agent.speed = 25;
                        notallowedToChangeSpeed = true;

                        if (transform.name == "Red_Racer3")
                        {
                            agent.speed = 27;
                        }
                        if (transform.name == "White_Racer")
                        {
                            agent.speed = 25.5f;
                        }
                        if (transform.name == "Black_Racer2")
                        {
                            agent.speed = 26.8f;
                        }
                    }
                    else if (slowBoat == true && hasCompletedPath1 == false && isFastBoat == true)
                    {
                        agent.speed = 50;
                        if (transform.name == "Green_Racer6")
                        {
                            agent.speed = 66;
                        }
                        if (transform.name == "Blue_Racer4")
                        {
                            agent.speed = 45;
                        }
                        if (transform.name == "Yellow_Racer5")
                        {
                            agent.speed = 55;
                        }


                        notallowedToChangeSpeed = true;
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
                else if (destinationCounter == 5)
                {
                    agent.SetDestination(target6.transform.position);
                    if (isFastBoat == true)
                    {
                        Invoke("changeSpeed", 3);
                    }
                    else
                    {
                        Invoke("changeSpeed", 7);
                    }
                    destinationCounter++;
                }
                else if (destinationCounter == 6)
                {

                   
                        agent.SetDestination(target7.transform.position);
                        Invoke("deactivate", 0.5f);
                    if (doOnce == false)
                    {
                        if (transform.name == "Red_Racer3")
                        {
                            agent.speed = 82;
                        }
                        if (transform.name == "White_Racer")
                        {
                            agent.speed = 77f;
                        }
                        if (transform.name == "Black_Racer2")
                        {
                            agent.speed = 71f;
                        }
                        if (transform.name == "Green_Racer6")
                        {
                            agent.speed = 73;
                        }
                        if (transform.name == "Blue_Racer4")
                        {
                            agent.speed = 55;
                        }
                        if (transform.name == "Yellow_Racer5")
                        {
                            agent.speed = 80;

                        }
                        doOnce = true;
                    }
                    destinationCounter++;
                    
                }
            

            else if (destinationCounter == 7)
            {
                agent.SetDestination(target8.transform.position);
                if (divertBoat == true && hasCompletedPath1 == true && lapCounter == 4)
                {
                    Invoke("disqualifyHim", 1f);

                }
                else
                {
                    destinationCounter++;
                }
                   

                }
            else if (destinationCounter == 8)
                {
                    agent.speed = 80;
                    agent.SetDestination(target9.transform.position);

                destinationCounter++;
            }
            else if (destinationCounter == 9)
            {
                agent.SetDestination(target10.transform.position);

                destinationCounter = 4;
                lapCounter++;
            }

            else if (destinationCounter == 10)
            {
                agent.SetDestination(target12.transform.position);
            }
            }
        }
        
    }
    public void deactivate()
    {
        clock.SetActive(false);
    }
    public void changeSpeed()
    {
        agent.speed = 80;
        agent.acceleration = 68;
    }
    public void disqualifyHim()
    {
        agent.speed = 105;
        agent.SetDestination(target8.transform.position);
        destinationCounter = 10;
        disqualify = true;
    }
    public void resetAllowToChange()
    {
        notallowedToChangeSpeed = false;
    }
    public void resetSpeed()
    {
        
        agent.speed = 15;
        if(isFastBoat==true)
        {
            agent.speed = 15;
        }


    }
    public void stopBoats()
    {
        agent.speed = 8;
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
