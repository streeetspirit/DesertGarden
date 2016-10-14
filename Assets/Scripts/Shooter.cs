using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject parent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start () {

		animator = GameObject.FindObjectOfType<Animator> ();
		parent = GameObject.Find ("Projectiles");

		if (!parent) {
			parent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update () {
		if (IsAttackerAhead ()) {
			animator.SetBool ("isAttacked", true);
		}
		else 
			animator.SetBool ("isAttacked", false);
	}

	//find myLaneSpaner to the one on the same lane
	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == (transform.position.y+0.5)) {
				myLaneSpawner = spawner;
			}
			else
				Debug.LogError ("no spawners with the same coordinate Y as a defender");
		}
	}

	bool IsAttackerAhead () {
		// exit if no attacker in lane
		if (myLaneSpawner.transform.childCount<=0)
			return false;

		// is an attacker ahead?
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x < transform.position.x) {
				return true;
			}
		}
		// all attackers behind
		return false;
	}
	 
	public void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = parent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
