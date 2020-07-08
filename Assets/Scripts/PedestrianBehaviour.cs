using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianBehaviour : MonoBehaviour
{
    public SimulationManager myManager;
    public float speed;
    bool turning = false;
    RaycastHit hit = new RaycastHit();

    void Start()
    {
        speed = UnityEngine.Random.Range(myManager.minSpeed, myManager.maxSpeed);
    }

    void Update()
    {
        FlockingRules();
        MoveTowardsGoal();

        if (Physics.Raycast(transform.position, this.transform.forward,out hit, 2) && hit.collider.gameObject.name != this.name )
        {
            if (myManager.avoidObstacles)
            {
                AvoidObstacles();
            }
        }
        else
        {
            
        }
    }

    private void AvoidObstacles()
    {
        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;

        if (Physics.Raycast(transform.position, this.transform.forward, out hit, 2)  )
        {
            //Debug.Log(hit.collider.gameObject.name);
            turning = true;
            //Debug.DrawRay(this.transform.position, this.transform.forward * 1, Color.red);
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
        }
        else
        {
            turning = false;
        }
        if (turning == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  myManager.rotationSpeed * Time.deltaTime);

            transform.Translate(0, 0, Time.deltaTime * (0.5f));
        }
    }

    private void FlockingRules()
    {
        GameObject[] allUnits;
        allUnits = myManager.units;

        Vector3 averageCenter = Vector3.zero;
        Vector3 averageAvoidance = Vector3.zero;
        float globalAverageSpeed = 0.01f;
        float neighbourDistance;
        int groupSize = 0;

        //////
        foreach (GameObject go in allUnits)
        {
            if (go != this.gameObject)
            {
                neighbourDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (neighbourDistance <= myManager.groupDistance)
                {
                    groupSize++;
                    averageCenter += go.transform.position;                   
                    PedestrianBehaviour anotherFlock = go.GetComponent<PedestrianBehaviour>();
                    globalAverageSpeed = globalAverageSpeed + anotherFlock.speed;
                }

                if (neighbourDistance < myManager.avoidDistance)
                {

                    averageAvoidance = averageAvoidance + (this.transform.position - go.transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                              Quaternion.LookRotation(averageAvoidance),
                                              myManager.rotationSpeed * Time.deltaTime);              
                }

            }
        }

        if (groupSize>0)
        {
            averageCenter = averageCenter / groupSize + (myManager.goalPos - this.transform.position);
            Vector3 direction = (averageCenter + averageAvoidance) - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    myManager.rotationSpeed * Time.deltaTime);
        }
        else
        {
            //this.transform.LookAt(myManager.goalPos);
        }
        
        
    }

    private void MoveTowardsGoal()
    {

        if (!turning)
        {
           transform.Translate(0, 0, Time.deltaTime * speed); 
        }
        else if (turning)
        {
            //transform.Translate(0, 0, Time.deltaTime * (-0.5f));
            turning = false;
        }

    }
}
