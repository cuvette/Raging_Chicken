using UnityEngine;
using System.Collections;

public class Disco : MonoBehaviour {

	Color[] colours = new Color[7];
	public float time = 1f;
	public float repeatRate = 1f;

	void Start()
	{
		colours[0] = Color.blue;
		colours[1] = Color.green;
		colours[2] = Color.red;
		colours [3] = Color.white;
		colours [4] = Color.yellow;
		colours [5] = Color.grey;
		colours [6] = Color.magenta;

		LightChange ();

	}

	void LightChange () 
	{
		InvokeRepeating("ChangeColour",time,repeatRate);
	}
	
	void ChangeColour()
		                {
		GetComponent<Light>().color = colours[Random.Range(0,colours.Length)];
	}
}
