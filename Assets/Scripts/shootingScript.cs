using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour {

    [SerializeField] int damageDealt = 20;

    Animator anim;

    [SerializeField] GameObject bloodHit;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButton("Fire1"))
        {
            print("fire");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            anim.SetTrigger("Fire");
            GetComponentInChildren<ParticleSystem>().Play();
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            

            if (Physics.Raycast (mouseRay, out hitInfo))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 5.0f);
                Health enemyHealth = hitInfo.transform.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(damageDealt);
                    Vector3 bloodHitPos = hitInfo.point;
                    Quaternion bloodHitRot = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
                    Instantiate(bloodHit, bloodHitPos, bloodHitRot);
                }
            }
        }
        else if(!Input.GetButton("Fire1"))
        {
            print("not fire");
            GetComponentInChildren<ParticleSystem>().Stop();
        }
		
	}
}
