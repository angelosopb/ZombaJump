using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	public Text info;

	// Use this for initialization
	void Start () {
		info.text += PlayerPrefs.GetInt ("Points", 0);
		StartCoroutine (wait ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 1) {
			if(Input.GetTouch(0).phase == TouchPhase.Ended){SceneManager.LoadScene ("MenuState");}
		}
	}
		
	IEnumerator wait(){
		yield return new WaitForSeconds (0.5f);
	}
}
