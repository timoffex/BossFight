using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SpiderScript : MonoBehaviour {
	
	 private Animator controller;



	public float restDuration = 1;
	public float chaseDuration = 3;

	private float lastRecordedTime = 0;


	private enum AIState { Chase, Rest };
	private AIState aiState = AIState.Rest;
	private Vector3 targetPosition;


	void Start () {
		controller = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		PerformAI ();
	}



	void PerformAI () {

		var player = NearestPlayer ();

		if (aiState == AIState.Rest) {
			controller.SetBool ("Moving", false);

			if (Time.time - lastRecordedTime > restDuration) {
				lastRecordedTime = Time.time;
				aiState = AIState.Chase;


				var noise = Random.insideUnitSphere;
				noise.z = 0;
				targetPosition = player.position + 10*noise;
			}
		} else {
			controller.SetBool ("Moving", true);

			var toTarget = targetPosition - transform.position;
			var dist = toTarget.magnitude;
			toTarget /= dist;


			FaceDirection (toTarget);

			var speed = 0.05f;

			if (dist > speed) {
				transform.position += toTarget * speed;
			}


			if (dist < speed || Time.time - lastRecordedTime > chaseDuration) {
				lastRecordedTime = Time.time;
				aiState = AIState.Rest;
			}
		}
	}

	void FaceDirection (Vector3 dir) {
		transform.up = -dir;
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
