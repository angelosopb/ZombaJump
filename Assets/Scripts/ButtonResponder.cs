using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResponder : MonoBehaviour {

	public GameObject menu;

	public void ChangeStart(){menu.SendMessage ("Play");}

	public void ChangeScore(){menu.SendMessage ("Score");}

	public void ChangeSettings(){menu.SendMessage ("Settings");}

	public void returnMenu(){menu.SendMessage ("VolverMenu");}

	public void BotonUpS(){menu.SendMessage ("SetBoton","BtnUpS");}

	public void BotonDownS(){menu.SendMessage ("SetBoton","BtnDownS");}

	public void BotonUpST(){menu.SendMessage ("SetBoton","BtnUpST");}

	public void BotonDownST(){menu.SendMessage ("SetBoton","BtnDownST");}

	public void BotonUpC(){menu.SendMessage ("SetBoton","BtnUpC");}

	public void BotonDownC(){menu.SendMessage ("SetBoton","BtnDownC");}
}