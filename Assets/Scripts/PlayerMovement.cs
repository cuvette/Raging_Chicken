using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	Rigidbody playerRigidbody;
	float camRaylength = 100f;
	Vector3 movement;

	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		//Animating()

	}
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.fixedDeltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

	}
	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRaylength))
		{
			Vector3 playertoMouse = floorHit.point - transform.position;

			playertoMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playertoMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

}