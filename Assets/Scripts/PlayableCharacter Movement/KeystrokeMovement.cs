using UnityEngine;
using System.Collections;

public class KeystrokeMovement : MonoBehaviour {


	public float characterSpeed = 0.2f;


	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		/** KEYBOARD **/
		bool w = Input.GetKey ("w");
		bool a = Input.GetKey ("a");
		bool s = Input.GetKey ("s");
		bool d = Input.GetKey ("d");


		Vector3 vel = new Vector3 (0, 0);

		if (w)
			vel += Vector3.up;// increase vertical motion
		else if (s)
			vel -= Vector3.up;// decrease vertical motion 
		if (a)
			vel -= Vector3.right;// decrease horizontal motion
		else if (d)
			vel += Vector3.right;// increase horizontal motion


		if (vel.magnitude > 0) {
			vel = vel.normalized * characterSpeed;

			animator.SetBool ("Moving", true);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, vel);
			transform.position += vel;
		} else {
			animator.SetBool ("Moving", false);
		}


			
	}
}
