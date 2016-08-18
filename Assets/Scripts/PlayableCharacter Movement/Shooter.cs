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
			GameObject bullet = GameObject.Instantiate (bulletPrefab, transform.position, Quaternion.identity) as GameObject;
			Rigidbody2D physics = bullet.GetComponent<Rigidbody2D> ();
			mousePosition = MouseMovement2D.getMousePosition ();
			physics.velocity = (mousePosition - transform.position).normalized * shooterSpeed;
		}
	}
}
