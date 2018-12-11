using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour {

    public enum Behaviours { Patrol, Combat, Heal};
    public Behaviours currBehaviour = Behaviours.Patrol;

    NavMeshAgent agent;
    //List of Array of Points- starts at number 0
    public GameObject waypoints;
    Transform[] points;
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
        points = waypoints.GetComponentInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        //can turn off auto braking to not stop between waypoints
        agent.autoBraking = false;
        GoToNextPoint();
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

    }

    void RunHealState()
    {

    }

    void RunCombatState()
    {

    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.SetDestination(points[destPoint].position);
        //if goes higher than the total number of waypoints -> go back to start of array
        destPoint = (destPoint + 1) % points.Length;
    }
}
