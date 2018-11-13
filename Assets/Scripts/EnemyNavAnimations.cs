using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavAnimations : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if(agent)
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }
		
	}

    
}
