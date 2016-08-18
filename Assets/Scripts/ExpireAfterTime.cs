using UnityEngine;
using System.Collections;

public class ExpireAfterTime : MonoBehaviour {

	public float lifespan;

	// Use this for initialization
	void Start () {
		StartCoroutine ("DelayedSelfDestruct");
	}

	IEnumerator DelayedSelfDestruct () {
		yield return new WaitForSeconds (lifespan);

		Destroy (gameObject);
	}
}
