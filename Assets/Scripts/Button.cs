using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject prefab;
	public static GameObject selectedDefender;

	private Text cost;
	private Button[] buttonArray;


	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		int defenderCost = prefab.GetComponent <Defender> ().starCost;

		cost = GetComponentInChildren<Text> ();
		if (!cost)
			Debug.LogWarning (name + " has no text");
		else
			cost.text = defenderCost.ToString ();

	}

	void OnMouseDown () {

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;

		selectedDefender = prefab;
	}
}
