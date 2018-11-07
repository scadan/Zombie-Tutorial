using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject camera1;

    public GameObject camera2;

	// Use this for initialization
	void Start () {

        camera1.SetActive(true);
        camera2.SetActive(false);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.DrawRay(transform.position, (transform.position + (new Vector3(5, 0, 0))), Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, 5))
        {
            print(hit.collider.gameObject);
            print("ray");
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        else
        {
            camera2.SetActive(true);
            camera1.SetActive(false);
        }
	}
}
