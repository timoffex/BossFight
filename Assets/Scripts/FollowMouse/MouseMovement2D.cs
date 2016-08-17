using UnityEngine;
using System.Collections;

public class MouseMovement2D : MonoBehaviour {

	private Vector3 mousePosition;
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/** MOUSE **/
		bool left = Input.GetMouseButtonDown (0);
		//bool right = Input.GetMouseButtonDown (1);
		//get mouse position
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // convert from screen to world coordinates
		if (left) //release projectile from weapon
			transform.position = Vector2.Lerp(transform.position, mousePosition, speed); //follow mouse in a line until collide

		/*if (right) //interact with object
			;*/
	}
}
