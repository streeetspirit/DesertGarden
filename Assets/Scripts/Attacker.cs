using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))] 

public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds betweeen appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * currentSpeed * Time.deltaTime);
		if (!currentTarget) anim.SetBool ("isAttacking", false);
		 
	}



	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}

	//called from the animator at time of the actual attack
	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health)
				health.DealDamage (damage);
		}

	}


	public void Attack (GameObject obj) {
		currentTarget = obj;

	}
}
