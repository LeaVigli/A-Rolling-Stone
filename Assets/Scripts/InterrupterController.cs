using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrupteurController : MonoBehaviour {

	public int code;
	private Rigidbody rb;
	private GameObject porte;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "key") {
			porte = GameObject.FindGameObjectWithTag ("Porte");
			porte.gameObject.SetActive (false);
		}
	}
}