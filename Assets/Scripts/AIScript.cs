﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour {

    public enum Behaviours { Patrol, Combat, Heal};
    public Behaviours currBehaviour = Behaviours.Patrol;

    NavMeshAgent agent;

    public Health healthScript;



    public Transform player, healthPoint;

    public int chaseDistance;

    public int findDistance;
    
    //List of Array of Points- starts at number 0
    public GameObject waypoints;
    public GameObject[] points;
    public int destPoint = 0;

    void RunBehaviours()
    {
        switch (currBehaviour)
        {
            case Behaviours.Patrol:
                RunPatrolState();
                break;

            case Behaviours.Combat:
                RunCombatState();
                break;

            case Behaviours.Heal:
                RunHealState();
                break;
        }
    }

	// Use this for initialization
	void Start () {
        healthScript = GetComponent<Health>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthPoint = GameObject.FindGameObjectWithTag("PickUp").transform;
        points = GameObject.FindGameObjectsWithTag("Waypoint");
    }
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
 	}

    void RunPatrolState()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            currBehaviour = Behaviours.Combat;
        }
        else if (agent.remainingDistance < 0.5f)
        {
            if (points.Length == 0)
            {
                return;
            }
            agent.SetDestination(points[destPoint].transform.position);
            //if goes higher than the total number of waypoints -> go back to start of array
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void RunHealState()
    {
        agent.SetDestination(healthPoint.position);
        if (agent.remainingDistance < 0.1f)
        {
            currBehaviour = Behaviours.Patrol;
        }
    }

    void RunCombatState()
    {
        if (Vector3.Distance(transform.position, player.position) < chaseDistance)
        {
            currBehaviour = Behaviours.Patrol;
        }
        else
        {
            agent.SetDestination(player.position);
        }
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

       
    }
}
