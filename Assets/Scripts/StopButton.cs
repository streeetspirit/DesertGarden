using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	private LevelManager lvlManager;

	// Use this for initialization
	void Start () {
		lvlManager = GameObject.FindObjectOfType <LevelManager>();
	}

	void OnMouseDown () {
		lvlManager.LoadLevel ("Start");
	}
}
