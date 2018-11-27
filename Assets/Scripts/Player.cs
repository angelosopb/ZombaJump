using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject game;
	public GameObject enemyGenerator;
	public AudioClip jump;
	public AudioClip hit;
	public ParticleSystem dust;
	private Animator animator;
	private AudioSource audioPlayer;
	private int hearts;
	private string jugabilidad;
	private float startY;
	private float posicionInicialY = 0.0f;
	private float posicionFinalY = 0.0f;
	//private float accelerometerUpdateInterval = 1.0f/60.0f;
	//private float lowPassKernelWidthInSeconds = 1.0f;
	//private float shakeDetectionThreshold = 2.0f;
	//private float lowPassFilterFactor;
	//private Vector3 lowPassValue;

	// Use this for initialization
	void Start () {
		//lowPassFilterFactor = accelerometerUpdateInterval/lowPassKernelWidthInSeconds;
		//shakeDetectionThreshold *= shakeDetectionThreshold;
		//lowPassValue = Input.acceleration;
		animator = GetComponent<Animator> ();
		audioPlayer = GetComponent<AudioSource> ();
		hearts = 3;
		jugabilidad = PlayerPrefs.GetString("Options");
		startY = transform.position.y;//Cogemos la posicion inicial del player
	}
	
	// Update is called once per frame
	void Update () {
		
		bool isStanding = transform.position.y == startY;
		if(Input.touchCount >= 1){
			//Obtenemos la posicion inicial al tocar la pantalla
			Touch touch = Input.GetTouch(0);
			bool up = false;
			bool duck = false;

			if(touch.phase == TouchPhase.Began){
				posicionInicialY = touch.position.y;
			}

			if (jugabilidad == "Clasico") {
				if (touch.phase == TouchPhase.Ended) {
					posicionFinalY = touch.position.y;
					up = posicionInicialY < posicionFinalY;
					duck = posicionInicialY > posicionFinalY;
				}
			} else {//Acelerometro
				//Vector3 acceleration = Input.acceleration;
				//lowPassValue = Vector3.Lerp (lowPassValue, acceleration, lowPassFilterFactor);
				//Vector3 deltaAcceleration = acceleration - lowPassValue;
				//if(deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold){
				//Sacudida
				//}
			}

			if (isStanding && up) {
				UpdateState("PlayerJump");
				audioPlayer.clip = jump;
				audioPlayer.Play ();
			}
			else if(isStanding && duck){
				UpdateState("PlayerDuck");
			}
		}
	}

	public void UpdateState(string state = null){
		if (state != null) {
			animator.Play (state);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Obstaculo" ) {
			hearts--;
			audioPlayer.clip = hit;
			audioPlayer.Play ();
			game.SendMessage ("BrokenHeart",hearts);

			if (hearts == 0) {
				enemyGenerator.SendMessage ("CancelGenerator", true);
				game.GetComponent<AudioSource> ().Stop ();
				DustStop ();
				game.SendMessage ("ResetTimeScale", 0.5f);
				game.SendMessage ("EndGame");
			}
		} 
	}
	void DustPlay(){
		dust.Play ();
	}

	void DustStop(){
		dust.Stop ();
	}

}
