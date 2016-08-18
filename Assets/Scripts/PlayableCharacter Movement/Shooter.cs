using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject bulletPrefab;
	private Vector3 mousePosition;
	public float shooterSpeed = 15.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool left = Input.GetMouseButtonDown (0);

		if (left){

			var direction = ((Vector2)(MouseMovement2D.getMousePosition () - transform.position)).normalized;


			GameObject bullet = GameObject.Instantiate (bulletPrefab, transform.position,
				Quaternion.LookRotation (Vector3.forward, direction)) as GameObject;
			

			Rigidbody2D physics = bullet.GetComponent<Rigidbody2D> ();

			physics.velocity = direction * shooterSpeed;
		}
	}
}
