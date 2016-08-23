using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
	public float health = 100.0f;

	public void TakeDamage (float dmg) {
		health -= dmg;
		print (health);
		// display damage taken
		if (health <= 0.0) {
			//display death animation
			Destroy (gameObject);
		}
	}
}
