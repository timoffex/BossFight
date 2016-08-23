using UnityEngine;
using System.Collections;

public class BoulderAI : MonoBehaviour {


	private BoulderActions actions;

	// Use this for initialization
	void Start () {
		actions = GetComponent<BoulderActions> ();
		StartCoroutine ("LateStart");
	}

	IEnumerator LateStart () {
		yield return new WaitForEndOfFrame ();
		StartCoroutine ("DecisionLoop");
	}

	IEnumerator DecisionLoop () {
		while (true) {
			// Do nothing.
			yield return new WaitForFixedUpdate ();
		}
	}
}
