using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCompute : MonoBehaviour {

	public static ScoreCompute instance;

	public Text P1_Score_Text;
	public Text P2_Score_Text;

	public int P1_Score;
	public int P2_Score;
	public int Flag;

	// Use this for initialization
	void Start () {
		instance = this;
		P1_Score = 0;
		P2_Score = 0;
		Flag = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (P1_Score == 3) {
			Flag = 1; 
			SceneManager.LoadScene (3);
		}
		if (P2_Score == 3) {
			Flag = 2;
			SceneManager.LoadScene (3);
		}
	}

	public void P1_Scored(){
		P1_Score += 1;
		P1_Score_Text.text = P1_Score.ToString ();
	}

	public void P2_Scored(){
		P2_Score += 1;
		P2_Score_Text.text = P2_Score.ToString ();
	}
		
}
