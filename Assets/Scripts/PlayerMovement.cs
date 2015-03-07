using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	float camRaylength = 100f;
	Vector3 movement;
	int floorMask;

	Rigidbody playerRigidbody;
	Animator anim;
	AudioSource playerAudio;
	
	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody>();
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerAudio = GetComponent<AudioSource> ();
	
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h,v);

	}
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.fixedDeltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
		if (Input.GetMouseButtonDown (0))
			playerAudio.Play ();
		if (Input.GetMouseButtonUp (0))
			playerAudio.Stop ();

	}
	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRaylength, floorMask)) {
			Vector3 playertoMouse = floorHit.point - transform.position;

			playertoMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playertoMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float h, float v)
		{
			bool run = h!=0f || v!=0f;
			anim.SetBool("IsRunning",run);
		}

}
