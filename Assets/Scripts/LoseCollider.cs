using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {

	private LevelManager lvlManager;

	// Use this for initialization
	void Start () {
		lvlManager = GameObject.FindObjectOfType <LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D () {
			lvlManager.LoadLevel ("Lose");
		
	}
}
