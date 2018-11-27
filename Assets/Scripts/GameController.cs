using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//Hacemos que el parallaxSpeed este entre este rango y editarlo en Unity
	[Range (0f,0.20f)]
	public float parallaxSpeed = 0.02f;
	public RawImage background;
	public RawImage platform;
	public Object[] hearts;
	public GameObject uiScore;
	public Text pointsText;

	public GameObject player;
	public GameObject enemyGenerator;

	public float scaleTime = 6f;
	public float scaleInc = .25f;

	private AudioSource musicPlayer;
	private int points = 0;

	// Use this for initialization
	void Start () {
		musicPlayer = GetComponent<AudioSource> ();
		musicPlayer.Play ();
		player.SendMessage ("DustPlay");
		enemyGenerator.SendMessage ("StartGenerator");
		InvokeRepeating ("GameTimeScale", scaleTime, scaleTime);
		//Incremento de puntos, inicialmente espera 6 segundos para empezar a llamar al metodo, y luego cada 3s lo llama
		InvokeRepeating ("IncreasePoints", scaleTime, 3f);
		StartCoroutine (wait ());//Hacemos esperar un segundo para que no colisionen los toques en la pantalla y funcione mal el juego
	}

	//Hacemos esperar un segundo para que no colisionen los toques en la pantalla y funcione mal el juego
	IEnumerator wait(){
		yield return new WaitForSeconds (0.3f);
	}

	// Update is called once per frame
	void Update () {
		Parallax ();
		pointsText.text = points.ToString ();
	}
		
	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed,0f,1f,1f);
		platform.uvRect = new Rect (platform.uvRect.x + finalSpeed * 4,0f,1f,1f);
	}

	void GameTimeScale(){
		Time.timeScale += scaleInc;
		Debug.Log ("Ritmo incrementado :" + Time.timeScale.ToString ());
	}

	public void ResetTimeScale(float newTimeScale = 1f){
		CancelInvoke ("GameTimeScale");
		Time.timeScale = newTimeScale;
		Debug.Log ("Ritmo restablecido");
	}

	public void IncreasePoints(){
		points++;
		if (points > GetMaxScore ()) {
			SaveScore (points);
		}
	}

	public int GetMaxScore(){
		return PlayerPrefs.GetInt ("Max Points", 0);
	}

	public void SaveScore(int currentPoints){
		PlayerPrefs.SetInt ("Max Points", currentPoints);
	}

	void EndGame(){
		PlayerPrefs.SetInt ("Points", points);
		SceneManager.LoadScene("GameOverState");
	}

	void BrokenHeart(int heart){
		Destroy (hearts [heart]);
	}
}