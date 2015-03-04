using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	NavMeshAgent nav;

	void Awake()
	{

		nav = GetComponent<NavMeshAgent> ();


	}
	void Update()
	{
		GameObject[] eggs = GameObject.FindGameObjectsWithTag ("Egg");
		GameObject target = null;
		foreach (GameObject egg in eggs) {
			if (target == null || Vector3.Distance(target.transform.position,transform.position)>Vector3.Distance(egg.transform.position, transform.position))
				target = egg;
		}
		if (target != null)
		
			nav.SetDestination(target.transform.position);
	}


		}