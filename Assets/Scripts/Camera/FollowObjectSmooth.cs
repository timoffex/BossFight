﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Smoothly follows the provided object.
/// </summary>
public class FollowObjectSmooth : MonoBehaviour {

	public Transform objectToFollow;


	private Camera cameraComponent;

	// Use this for initialization
	void Start () {
		cameraComponent = GetComponent<Camera> (); // Gets a reference to the "Camera" component of our object.
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		// Vector from our position to the object's position.

		var dif = objectToFollow.position - transform.position;
		dif.z = 0;	// We don't want to move along the z axis.




		var viewportDif = cameraComponent.WorldToViewportPoint (objectToFollow.position) * 2 - Vector3.up - Vector3.right;
		viewportDif.z = 0; // we don't care about difference along z axis



		// Positive number.
		// 0 means the object is centered, and we're good.
		// 1 means the object is almost off the screen.
		// We want this number to be approximately 0.2-0.3
		var error = viewportDif.magnitude;



		// How this works:
		//		"percentage" is the percentage of the distance from our object that we should move.
		//		percentage == 0 means "don't move" and percentage == 1 means "put camera over object"

		//		The percentage is calculated in a nice way such that if error >= 0.4 we will move the camera
		//		such that the error becomes 0.3. When the error is less than 0.4, we try to still move the camera,
		//		but slowly.

		const float preferred = 0.3f;
		const float cutoff = preferred + 0.1f;
		const float minimum = 0.1f;

		var percentage = 0f;
		if (error >= cutoff)
			percentage = 1.0f - preferred/error;
		else
			percentage = minimum + (0.25f - minimum) * error * error / (preferred * preferred);



		transform.position += dif * percentage;
	}
}
