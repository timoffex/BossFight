using UnityEngine;
using System.Collections;

public class SpiderScript : MonoBehaviour {


	private Animator controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		controller.SetBool ("Moving", true);

		var player = NearestPlayer ();

		var towardPlayer = (player.position - transform.position).normalized;

		transform.up = -towardPlayer;
		transform.position += towardPlayer*0.1f;
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
