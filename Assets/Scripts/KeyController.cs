using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	public int code;
	public string type;
	private bool state = false;
	private Rigidbody rb;
	private Vector3 pos,pos2;

	void Start ()
	{   
		rb = GetComponent<Rigidbody>();
		pos2 = rb.transform.position;
		pos = new Vector3(pos2.x,pos2.y,pos2.z);
	}

	void OnTriggerEnter(Collider collider) {
		if (type == "pont") {
			if (collider.gameObject.name == "Player") {
				state = true;
				GameObject.Find ("Pont").transform.position = new Vector3 (-0.03f, 0.7f, 3.91f);
				//GameObject.Find("Pont").SetActive(false);
			}
		} else if (type == "porte") {
			if (collider.gameObject.name == "Player") {
				GameObject.Find ("Porte"+code).SetActive (false);
			}
		}
	}


}