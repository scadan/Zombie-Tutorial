using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Health healthScript;
    public Text healthText;
    public Slider healthBar;

    public Text scoreNum;
    public Text timeNum;
    public static int score;

    public GameObject youLoseCanvas;

	// Use this for initialization
	void Start () {

       youLoseCanvas.SetActive(false);
		
	}

    public static void updateScore(int amount)
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


        score += amount;
    }
	
	// Update is called once per frame
	void Update () {

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthText.text = "Health: " + healthScript.getHealth();

        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";

        if (healthScript.IsDead) 
        {
        youLoseCanvas.SetActive(true);

        Time.timeScale = 0;
        }
    }
}
