using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject inicial;
	public GameObject ajustes;
	public GameObject toggle;
	public Text info;
	public RawImage background;
	public RawImage logo;
	public Button start;
	public Button score;
	public Button settings;
	public Button settings2;
	private ToggleGroup tl;
	private string boton = "";

	// Use this for initialization
	void Start () {
		tl = toggle.GetComponent<ToggleGroup>();
		PlayerPrefs.SetString ("Options", "Clasico");
	}

	// Update is called once per frame
	void Update () {
		if(Opcion ()=="Clasico"){
			info.text = "Para jugar este modo basta con deslizar el dedo hacía arriba para saltar y hacía abajo para agacharse";
		}
		else if(Opcion ()=="Accelerometro"){
			info.text ="Para jugar este modo basta con agachar hacía delante el movil para saltar y hacía a ti para agacharse";
		}
		switch (boton) {
		case "BtnUpS":
			score.image.overrideSprite = Resources.Load<Sprite> ("Sprites/score_button");
			break;
		case "BtnDownS":
			score.image.overrideSprite = Resources.Load<Sprite> ("Sprites/score_button_down");
			break;
		case "BtnUpST":
			start.image.overrideSprite = Resources.Load<Sprite> ("Sprites/start_button");
			break;
		case "BtnDownST":
			start.image.overrideSprite = Resources.Load<Sprite> ("Sprites/start_button_down");
			break;
		case "BtnUpC":
			settings.image.overrideSprite = Resources.Load<Sprite> ("Sprites/settings_button");
			settings2.image.overrideSprite = Resources.Load<Sprite> ("Sprites/settings_button");
			break;
		case "BtnDownC":
			settings.image.overrideSprite = Resources.Load<Sprite> ("Sprites/settings_button_down");
			settings2.image.overrideSprite = Resources.Load<Sprite> ("Sprites/settings_button_down");
			break;
		}
	}

	string Opcion(){
		Toggle aux = tl.ActiveToggles ().FirstOrDefault();
		if (aux == null) {
			return "";
		} else {
			return aux.gameObject.name;
		}
	}

	void SetBoton(string btn){
		boton = btn;
	}

	void Play(){SceneManager.LoadScene("PlayState");}

	void Score(){SceneManager.LoadScene("ScoreState");}

	void Settings(){
		ajustes.SetActive (true);
		inicial.SetActive (false);
	}

	void VolverMenu(){
		switch (Opcion()) 
		{
		case "Clasico":
			PlayerPrefs.SetString ("Options", "Clasico");
			break;
		case "Accelerometro":
			PlayerPrefs.SetString ("Options", "Accelerometro");
			break;
		}
		inicial.SetActive (true);
		ajustes.SetActive (false);
	}
}
