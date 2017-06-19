using UnityEngine;
using System.Collections;

public class KeyRotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 38, 0) * Time.deltaTime * 2);
	}
}
