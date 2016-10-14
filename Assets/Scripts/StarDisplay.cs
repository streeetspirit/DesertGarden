using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]

public class StarDisplay : MonoBehaviour {

	private Text score;
	public int scoreNum = 200;

	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
		UpdateDisplay ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStars (int amount) {
		scoreNum += amount;
		UpdateDisplay ();
	}

	public Status UseStars (int amount) {
		if (scoreNum >= amount) {
			scoreNum -= amount;
			UpdateDisplay ();


			return Status.SUCCESS;
		} else {
			return Status.FAILURE;
		}
	}

	private void UpdateDisplay () {
		score.text = scoreNum.ToString ();
	}
}
