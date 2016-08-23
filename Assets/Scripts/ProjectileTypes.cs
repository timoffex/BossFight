using UnityEngine;
using System.Collections;

public class ProjectileTypes : MonoBehaviour {
	public float damage = 0.0f;

	void OnCollisionEnter2D (Collision2D col){
		print (col.gameObject.name);
		var combat = col.gameObject.GetComponent<Combat>();
		if (combat == null) {
			print ("Combat.cs is null");
		} else {
			combat.TakeDamage (damage);
			Destroy (gameObject);
		}
	}
}
