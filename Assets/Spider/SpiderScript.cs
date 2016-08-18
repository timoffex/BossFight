using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SpiderScript : MonoBehaviour {
	
	 private Animator controller;



	public float restDuration = 1;
	public float chaseDuration = 3;

	private float nextRestDuration;
	private float nextChaseDuration;
	private float lastRecordedTime = 0;


	private enum AIState { Chase, Rest };
	private AIState aiState = AIState.Rest;
	private Vector3 targetPosition;


	void Start () {
		controller = GetComponent<Animator> ();

		nextRestDuration = restDuration;
		nextChaseDuration = chaseDuration;
	}

	// Update is called once per frame
	void Update () {
		PerformAI ();
	}



	void PerformAI () {

		var player = NearestPlayer ();

		if (aiState == AIState.Rest) {
			controller.SetBool ("Moving", false);

			if (Time.time - lastRecordedTime > nextRestDuration) {
				lastRecordedTime = Time.time;
				aiState = AIState.Chase;
				nextChaseDuration = chaseDuration + (Random.value-0.5f)*2;


				var noise = Random.insideUnitSphere;
				noise.z = 0;
				targetPosition = player.position + 4*noise;
			}
		} else {
			controller.SetBool ("Moving", true);

			var toTarget = targetPosition - transform.position;
			var dist = toTarget.magnitude;
			toTarget /= dist;


			FaceDirection (toTarget);

			var speed = 0.1f;

			if (dist > speed) {
				transform.position += toTarget * speed;
			}


			if (dist < speed || Time.time - lastRecordedTime > nextChaseDuration) {
				lastRecordedTime = Time.time;
				aiState = AIState.Rest;
				nextRestDuration = restDuration + (Random.value-0.5f);
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
