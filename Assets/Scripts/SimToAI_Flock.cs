using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SimToAI_Flock : MonoBehaviour {

	
	GameObject goal;

	void Start () {
		
		GetComponent<AIDestinationSetter>().target = GetComponent<PedestrianBehaviour>().myManager.goal.transform;
		GetComponent<AIPath>().maxSpeed = GetComponent<PedestrianBehaviour>().speed;
		GetComponent<Statistics>().speed = GetComponent<PedestrianBehaviour>().speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
