using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {
		score.text += PlayerPrefs.GetInt ("Max Points", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touches.Length>=1){SceneManager.LoadScene("MenuState");}
	}
}
