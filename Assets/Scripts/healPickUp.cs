 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        print("pick up");
        if (collider.CompareTag("Player"))
        {

            Health health = collider.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.Damage(-50);
            }
        }
    }
}
