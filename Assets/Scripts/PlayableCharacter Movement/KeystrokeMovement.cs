using UnityEngine;
using System.Collections;

public class KeystrokeMovement : MonoBehaviour {


	public float characterSpeed = 0.2f;


	private Animator animator;
	private Rigidbody2D rbd;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rbd = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		/** KEYBOARD **/
		bool w = Input.GetKey ("w");
		bool a = Input.GetKey ("a");
		bool s = Input.GetKey ("s");
		bool d = Input.GetKey ("d");


		Vector2 vel = new Vector2 (0, 0);

		if (w)
			vel += Vector2.up;// increase vertical motion
		else if (s)
			vel -= Vector2.up;// decrease vertical motion 
		if (a)
			vel -= Vector2.right;// decrease horizontal motion
		else if (d)
			vel += Vector2.right;// increase horizontal motion



		if (vel.magnitude > 0) {
			int movementIndex = (int)((vel.x + 1) - (vel.y - 1) * 3);
			animator.SetInteger ("MovementIndex", movementIndex);


			vel = vel.normalized * characterSpeed;

			animator.SetBool ("Moving", true);
			rbd.MovePosition(rbd.position + vel);
		} else {
			animator.SetBool ("Moving", false);
		}


			
	}
}
