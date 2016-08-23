using UnityEngine;
using System.Collections;

public class ProjectileTypes : MonoBehaviour {
	public float damage = 0.0f;

	public bool damagePlayer = true;

	void OnTriggerEnter2D (Collider2D col){
		print (col.gameObject.name);

		// Only deal damage if whether we want to hit a player agrees with whether we would hit a player.
		if (col.gameObject.tag.Equals ("Player") == damagePlayer) {
			var combat = col.gameObject.GetComponent<Combat> ();

			if (combat == null) {
				print ("Combat script not attached.");
			} else {
				combat.TakeDamage (damage);
				Destroy (gameObject);
			}
		}

	}
}
