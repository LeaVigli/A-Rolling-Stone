using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {
	GameObject Small_box; 

	void OnTriggerEnter (Collider Other){

		if(Other.gameObject.tag == "Player"){

			Small_box.GetComponent<Animation> ().Play ("3-2_boiteBois");
			Debug.Log("test animation");

		}

	}
}
