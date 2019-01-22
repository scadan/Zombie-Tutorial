using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 100;
    int currentHealth = 0;

    Animator anim;

    public Renderer renderer;

    public randomSpawn randomSpawnScript;

	// Use this for initialization
	void Start () {
        currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();
        
		
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
		if (IsDead&&!renderer.isVisible)
        {
            Destroy(gameObject);
        }
	}

    public void Damage(int damageValue)
    {
        if (IsDead) {
            return;
        }
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                if (anim)
                {
                    anim.SetBool("Dead", true);
                   

                }
                randomSpawnScript.numberSpawned--;

                StartCoroutine(Despawn());

                UIScript.updateScore(50);

                Destroy(GetComponent<AIScript>());
                print("DEAD");
                GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped=true;
                Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
                Destroy(GetComponent<CharacterController>());
                Destroy(GetComponentInChildren<EnemyAttack>());
                this.enabled = false;

                gameObject.name += " (Dead)";

                

                
            }
        }

        
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);

        print("Despawned");
    }
}
