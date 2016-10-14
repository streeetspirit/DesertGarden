using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {


	// public static LevelManager instance = null;

	public float autoLoadNextLevelAfter;


	void Start () {
		if (autoLoadNextLevelAfter <= 0) Debug.Log ("Level auto level disabled, use positive number in seconds");
			else Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
	}

	public void LoadLevel (string name) {

		SceneManager.LoadScene(name);
	}

	public void QuitRequest () {
		Debug.Log ("I want to quit!");
		Application.Quit();
	}

	public void LoadNextLevel() {

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}



}
