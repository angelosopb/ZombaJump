using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour {

	public GameObject[] enemyPrefab;
	public float generatorTimer = 1.75f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void CreateEnemy(){
		int i= Random.Range (0, 3);
		if (i == 0) {
			Instantiate (enemyPrefab [i], new Vector3 (10f, 1.5f, 0f), Quaternion.identity);
		} else if (i == 2) {
			Instantiate (enemyPrefab [i], new Vector3 (10f, -2.21f, 0f), Quaternion.identity);
		} else {
			Instantiate (enemyPrefab [i], transform.position, Quaternion.identity);
		}
	}

	public void StartGenerator(){
		InvokeRepeating ("CreateEnemy", 0f, generatorTimer);
	}

	public void CancelGenerator(bool clean = false){
		CancelInvoke ("CreateEnemy");
		if (clean) {
			Object[] allEnemies = GameObject.FindGameObjectsWithTag ("Obstaculo");
			foreach (GameObject enemy in allEnemies) {
				Destroy (enemy);
			}
		}
	}
}