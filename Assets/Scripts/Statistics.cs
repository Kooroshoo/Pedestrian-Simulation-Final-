using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour {

	static int totalAgentNumber = 0;
	int thisAgentNumber;
	bool setAgentNumber = false;
	bool reachedDestination = false;
	bool jobDone = false;
	int numberOfCollisions = 0;
	float endTime = 120.0f;
	float dist;
	float timespent=0;
	public float speed;
	Vector3 targetPosition;
	Vector3 selfPosition;



	// Use this for initialization
	void Start () {
		totalAgentNumber++;
		targetPosition = GameObject.Find("Target 1").transform.position;
		selfPosition = this.transform.position;
		dist = Vector3.Distance(selfPosition, targetPosition);
		timespent = endTime;
        if (setAgentNumber == false)
        {
			thisAgentNumber = totalAgentNumber;
			setAgentNumber = true;
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		endTime -= Time.deltaTime;
		if (endTime <= 0.0f)
		{
			timerEnded();
		}
	}
	private void OnTriggerEnter(Collider other)
	{
        if (jobDone == false)
        {
			
			reachedDestination = true;
			timespent = timespent - endTime;
			
			Debug.Log("Agent Number = " + thisAgentNumber + "; Reached Destination: " + reachedDestination + "; Starting Position: " + selfPosition + "; Distance to Target: " + Math.Round(dist, 2) + "; Speed: " + Math.Round(speed, 2) + "; Time Spent: " + Math.Round(timespent,2)   + "; #collisions: " + numberOfCollisions);
			jobDone = true;

		}

	
	}

	void OnCollisionEnter(Collision collision)
	{

		numberOfCollisions++;


	}
	void timerEnded()
	{
        if (reachedDestination == false && jobDone ==false)
        {
			timespent = timespent - endTime;
			Debug.Log("Agent Number = " + thisAgentNumber + "; Reached Destination: " + reachedDestination + "; Starting Position: " + selfPosition + "; Distance to Target: " + Math.Round(dist, 2) + "; Speed: " + Math.Round(speed, 2) + "; Time Spent: " + Math.Round(timespent, 2) + "; #collisions: " + numberOfCollisions);
			jobDone = true;
		}
	}
}
