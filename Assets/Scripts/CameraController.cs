using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject ground;

	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - ground.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = ground.transform.position + offset;
	}
}
