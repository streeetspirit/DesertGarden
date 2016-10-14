using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private Animator anim;
	public float health = 50f;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void DealDamage (float damage) {
		health -= damage;
		if (health < 0) {
			// add trigger animation
			anim.SetTrigger ("isDead");
			Invoke ("DestroyObject", 0.5f);

		}
	}

	public void DestroyObject () {
		
		Destroy (gameObject);
	}
}
