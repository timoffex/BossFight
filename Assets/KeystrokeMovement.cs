using UnityEngine;
using System.Collections;

public class KeystrokeMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		/** KEYBOARD **/
		bool w = Input.GetKey ("w");
		bool a = Input.GetKey ("a");
		bool s = Input.GetKey ("s");
		bool d = Input.GetKey ("d");


		float speed = 0.2F;

		if (w)
			transform.position += Vector3.up * speed;// increase vertical motion
		else if (s)
			transform.position -= Vector3.up * speed;// decrease vertical motion 
		if (a)
			transform.position -= Vector3.right * speed;// decrease horizontal motion
		else if (d)
			transform.position += Vector3.right * speed;// increase horizontal motion

		/** MOUSE **/
		bool left = Input.GetMouseButtonDown (0);
		bool right = Input.GetMouseButtonDown (1);

		if (left) //release projectile from weapon
			;
		if (right) //interact with object
			;

			
	}
}
