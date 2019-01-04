using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Slider playerHealth;
    public Text score;
    public Text playerHealthTxt;
    public Text timeTxt;

	public bool won = false;

	public GameObject youWinCanvas;

	
	// Use this for initialization
	void Start () {
		youWinCanvas.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 180) 
		{
			won = true;
		}

		if (won == true) {
			youWinCanvas.SetActive(true);
			Time.timeScale = 0;
		}
	}

   
}
