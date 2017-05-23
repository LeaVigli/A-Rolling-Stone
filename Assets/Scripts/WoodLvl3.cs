using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLvl3 : MonoBehaviour {

	public float speed;
	private float z;
		
    private Rigidbody rb;
	private Vector3 pos,pos2;

    void Start ()
    {   
        rb = GetComponent<Rigidbody>();
        pos2 = rb.transform.position;
		pos = new Vector3(pos2.x,pos2.y,pos2.z);
    }

    void FixedUpdate ()
    {	
		if(pos2.z <= -9){
			rb.transform.Translate(Vector3.forward * Time.deltaTime);
		}else{
			rb.transform.Translate(Vector3.back * Time.deltaTime);
		}
    
    }

	void OnTriggerEnter(Collider other)
	{      
		if (other.gameObject.CompareTag("SpecialWall"))
        {
			rb.transform.position = pos;
        }

    }
}
