using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scaling : MonoBehaviour {

	GameObject cone;
	public float scaleValue = 0.2f;
	public float maxScale = 20f;
	private List<GameObject> touched;
	public float power = 100f;



	void Start ()
	{
		cone = GameObject.Find ("cone");
		touched = new List<GameObject>();
	}

	
	void Update ()
	{
		if (Input.GetKey (KeyCode.Mouse0) && cone.transform.localScale.x <= maxScale)
			cone.transform.localScale += new Vector3 (scaleValue, scaleValue, scaleValue);
		else
			cone.transform.localScale = new Vector3 (0, 0, 0);
		if (Input.GetMouseButtonUp (0)||cone.transform.localScale.x >= maxScale)
			Debug.Log ("Fire");
			Fire();
			
		}
	
	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "Enemy")
		{
			touched.Add(other.gameObject);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			touched.Remove(other.gameObject);
		}
	}
	public void Fire()
	{
		for(int i=0; i<touched.Count; i++)
		{
			if(touched[i]==null)
				continue;
			touched[i].GetComponent<Rigidbody>().AddForce(transform.forward * power);
		}
	}
	
}