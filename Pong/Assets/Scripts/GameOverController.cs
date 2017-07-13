using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	public Text P1_Score_Text;
	// Use this for initialization
	void Start () {
		TextChanger ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TextChanger(){
		if (ScoreCompute.instance.Flag == 1) {
			P1_Score_Text.text = "Player 1 Wins";
		}
		if (ScoreCompute.instance.Flag == 2) {
			P1_Score_Text.text = "Player 2 Wins";
		}
	}

	public void MenuLevel(){
		SceneManager.LoadScene (0);
	}
}
