using Pathfinding;
using Pathfinding.RVO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimToAI_Orca : MonoBehaviour {

	public OrcaManeger orcaManager;
	public GameObject goal;
	float speed;

	// Use this for initialization
	void Start () {
		//orcaManager = FindObjectOfType<OrcaManeger>();
		//goal = orcaManager.goal;
		GetComponent<AIDestinationSetter>().target = goal.transform;
		speed = UnityEngine.Random.Range(orcaManager.minSpeed, orcaManager.maxSpeed);
		GetComponent<AIPath>().maxSpeed = speed;
		GetComponent<AIPath>().radius = orcaManager.avoidDistance;
		GetComponent<AIPath>().rotationSpeed = orcaManager.rotationSpeed;
		GetComponent<RVOController>().maxNeighbours = orcaManager.maxNeighbours;
		GetComponentInChildren<Statistics>().speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
