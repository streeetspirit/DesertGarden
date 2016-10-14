using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parentDefender;
	private StarDisplay starDisplay;

	void Start () {
		parentDefender = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!parentDefender) {
			parentDefender = new GameObject ("Defenders");
		}
	}


	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);

		int defenderCost = Button.selectedDefender.GetComponent <Defender> ().starCost;
			
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {	
			if (Button.selectedDefender && (roundedPos.y < 6.5)) {
				GameObject defender = Instantiate (Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
				defender.transform.parent = parentDefender.transform;
			}
		} else {
			Debug.Log ("Insufficient stars");
		}
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		//float newX = rawWorldPos.x;
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distFromCamera);
		Vector2	coordWorld = myCamera.ScreenToWorldPoint (weirdTriplet);
		return coordWorld;
	}
}
