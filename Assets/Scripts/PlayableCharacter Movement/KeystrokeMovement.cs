using UnityEngine;
using System.Collections;

public class KeystrokeMovement : MonoBehaviour {


	public float characterSpeed = 0.2f;

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


		if (w)
			transform.position += Vector3.up * characterSpeed;// increase vertical motion
		else if (s)
			transform.position -= Vector3.up * characterSpeed;// decrease vertical motion 
		if (a)
			transform.position -= Vector3.right * characterSpeed;// decrease horizontal motion
		else if (d)
			transform.position += Vector3.right * characterSpeed;// increase horizontal motion



			
	}
}
