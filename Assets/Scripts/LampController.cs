using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour {

	public float distance;
	public float vitesse;
	public string axe;
	int direction = 1;
	private Vector3 pos;

	private Rigidbody rb;

	void Start ()
	{   
		rb = GetComponent<Rigidbody>();
		pos = rb.transform.position;
	}

	void Update() {
		if (axe == "z") {
			if (rb.transform.position.z > pos.z + distance)
				direction = -1;
			else if (rb.transform.position.z < pos.z)
				direction = 1;

			rb.transform.position = transform.position + new Vector3 (0, 0, vitesse * direction * Time.deltaTime);
		} else if (axe == "x") {
			if (rb.transform.position.x > pos.x + distance)
				direction = -1;
			else if (rb.transform.position.x < pos.x)
				direction = 1;

			rb.transform.position = transform.position + new Vector3 (vitesse * direction * Time.deltaTime, 0, 0);
		}
	}

}