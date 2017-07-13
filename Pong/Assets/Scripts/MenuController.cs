using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OriginalLevel(){
		SceneManager.LoadScene (1);
	}

	public void ModifiedLevel(){
		SceneManager.LoadScene (2);
	}

	public void QuitLevel(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else	
		Application.Quit();
		#endif
	}
}
