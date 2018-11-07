using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    void OnDisable()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
    }
}
