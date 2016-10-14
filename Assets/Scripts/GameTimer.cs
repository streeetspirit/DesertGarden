using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSec = 10f;

	private Slider slider;
	private AudioSource audioSource;
	public bool isEndOfLevel = false;
	private LevelManager lvlMngr;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		lvlMngr = GameObject.FindObjectOfType<LevelManager> ();
		winLabel = GameObject.Find ("Win cond");
		if (!winLabel)
			Debug.LogWarning ("Create Win cond object");
		else
			winLabel.SetActive (false);
			
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSec;

		if (Time.timeSinceLevelLoad >= levelSec && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	void DestroyAllTaggedObjects () {
		GameObject[] toDestroy;
		toDestroy = GameObject.FindGameObjectsWithTag ("destroyOnWin");

		foreach (GameObject obj in toDestroy)
			Destroy (obj);

	}

	void LoadNextLevel () {
		lvlMngr.LoadNextLevel ();
	}
}
