using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour {

	public float speed;
	private float z;

    private Rigidbody rb;
	private Vector3 pos,pos2;

    void Start ()
    {   

    	/*float x=0.53f+0.5f;
		float y=10.51749f-11.5f;*/
		z=-16.89f+6.0f;//config OK ! plus qu'a changer x,y,z pour chaque rondin
        rb = GetComponent<Rigidbody>();
        pos2 = rb.transform.position;
		pos = new Vector3(pos2.x,pos2.y,z);
    }

    void FixedUpdate ()
    {
	rb.transform.Translate(Vector3.forward * Time.deltaTime);
    
    }

	void OnTriggerEnter(Collider other)
	{      
		if (other.gameObject.CompareTag("SpecialWall"))
        {
			rb.transform.position = pos;
        }

    }
}
