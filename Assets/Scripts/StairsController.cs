using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour {

	public int code;
	private Rigidbody rb;
	//private GameObject otherStair;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "Stairs1") {
			rb.MovePosition (GameObject.Find("Stairs11").transform.position);
		}
		if (collider.gameObject.name == "Stairs2") {
			rb.MovePosition (GameObject.Find("Stairs22").transform.position);
		}
	}
}