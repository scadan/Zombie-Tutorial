using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 100;
    int currentHealth = 0;

	// Use this for initialization
	void Start () {
        currentHealth = maximumHealth;

		
	}

    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                UIScript.updateScore(50);
            }
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
