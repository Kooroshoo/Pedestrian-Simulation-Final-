using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaManeger : MonoBehaviour {

    public GameObject[] units;
    public GameObject unitprefab;
    public int numUnits = 10;
    public Vector3 range = new Vector3(5, 5, 5);
    public GameObject goal;
    public Vector3 goalPos;

    [Header("Crowd Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public int maxNeighbours;
    [Range(0.5f, 3.0f)]
    public float avoidDistance;
    [Range(1f, 360.0f)]
    public float rotationSpeed = 360f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(this.transform.position, range * 2);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        units = new GameObject[numUnits];
        for (int i = 0; i < numUnits; i++)
        {
            Vector3 unitPos = new Vector3(Random.Range(-range.x, range.x),
                                      range.y,
                                      Random.Range(-range.z, range.z));
            units[i] = Instantiate(unitprefab, this.transform.position + unitPos, Quaternion.identity) as GameObject;
            units[i].GetComponent<SimToAI_Orca>().orcaManager = this.gameObject.GetComponent<OrcaManeger>();
            units[i].GetComponent<SimToAI_Orca>().goal = goal;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
