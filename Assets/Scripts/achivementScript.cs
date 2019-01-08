using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achivementScript : MonoBehaviour
{

    public GameObject deathBadge;
    public GameObject surviveBadge;

    
    float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        deathBadge.SetActive(false);
        surviveBadge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (UIScript.score >= 100) {

            deathBadge.SetActive(true);
        }

        if (timer > 60) {
            surviveBadge.SetActive(true);
        }
    }
}
