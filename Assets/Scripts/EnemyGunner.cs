using UnityEngine;
using System.Collections;

public class EnemyGunner : MonoBehaviour {

	public GameObject bulletPrefab;


	public float bulletSpeed = 1f;
	public float burstPeriod = 1f;
	public float burstDuration = 2f;

	/// <summary>
	/// Shots per second.
	/// </summary>
	public float burstFrequency = 3f;


	private float minDist = 5f;
	private float maxDist = 10f;
	private float speed = 0.2f;




	void Start () {
		StartCoroutine ("LateStart");
	}

	IEnumerator LateStart () {
		yield return new WaitForFixedUpdate ();
		StartCoroutine ("MakeDecision");
	}



	IEnumerator MakeDecision () {
		// Prioritize keeping a specific distance from the player.
		// Shoot when not moving.



		while (true) {
			var player = NearestPlayer ();
			var distToPlayer = Vector2.Distance (transform.position, player.position);


			if (IsSafeFrom (player)) {
				// We're good. Try shooting.

				yield return StartCoroutine ("Shoot", player);

			} else {
				// Move move move!!


				var toPlayer = (player.position - transform.position).normalized;

				var offset = -toPlayer * (minDist + Random.value * (maxDist - minDist));
				var randomRotation = Quaternion.Euler (0, 0, (Random.value - 0.5f) * 2);

				var location = (Vector2) (randomRotation * offset + player.position);


				yield return StartCoroutine ("MoveToLocation", location);

			}
		}
	}



	IEnumerator Shoot (Transform target) {
		float startTime = Time.time;

		while (Time.time - startTime < burstDuration & IsSafeFrom (target)) {
			FireBulletAt (target);
			yield return new WaitForSeconds (1f / burstFrequency);
		}
	}

	// This is called a "coroutine." It allows for "yield" statements, which sort of pauses the function
	// until the next frame and lets the other game code continue.
	IEnumerator MoveToLocation (Vector2 position) {
		
		float dist = Vector2.Distance (transform.position, position);

		transform.position = Vector2.MoveTowards (transform.position, position, speed);

		while (!Mathf.Approximately (dist, 0f)) {
			yield return new WaitForFixedUpdate ();

			transform.position = Vector2.MoveTowards (transform.position, position, speed);
			dist = Vector2.Distance (transform.position, position);
		}
	}


	bool IsSafeFrom (Transform t) {
		var distance = Vector2.Distance (transform.position, t.position);

		return distance > minDist && distance < maxDist;
	}


	void FireBulletAt (Transform target) {
		var toTarget = ((Vector2)(target.position - transform.position)).normalized;

		var bullet = GameObject.Instantiate (bulletPrefab, transform.position, Quaternion.LookRotation (Vector3.forward, toTarget)) as GameObject;

		var physics = bullet.GetComponent<Rigidbody2D> ();
		physics.velocity = toTarget * bulletSpeed;
	}


	Transform NearestPlayer () {
		var players = GameObject.FindGameObjectsWithTag ("Player");

		var minDist = Mathf.Infinity;
		GameObject closest = null;

		foreach (GameObject p in players) {
			var dist = (p.transform.position - transform.position).sqrMagnitude;

			if (dist < minDist) {
				minDist = dist;
				closest = p;
			}
		}

		return closest.transform;
	}
}
