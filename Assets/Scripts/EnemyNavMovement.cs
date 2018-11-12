using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMovement : MonoBehaviour {

    NavMeshAgent agent;

    [SerializeField]
    private GameObject target;

	// Use this for initialization
	void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);

        if(agent.remainingDistance<(agent.stoppingDistance+0.5f))
        {
            transform.LookAt(target.transform);
        }
	}
}
