using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObj) {
		GameObject myAttacker = Instantiate (myGameObj) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

	bool isTimeToSpawn (GameObject attackerGameObj) {
		float spawnTime = attackerGameObj.GetComponent<Attacker> ().seenEverySeconds;
		float spawnsPerSecond = 1 / spawnTime;

		// if frame rate is too slow
		if (Time.deltaTime > spawnTime)
			Debug.LogWarning ("Spawn rate capped by frame rate");

		float threshold = spawnsPerSecond * Time.deltaTime/6;

		return (Random.value < threshold);

	}
}
