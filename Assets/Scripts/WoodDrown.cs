using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDrown : MonoBehaviour {

	private int press;
	public float speed;
	private float z;
		
    private Rigidbody rb;
	private Vector3 pos,pos2;

    void Start ()
    {   
		press=0;
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {	
    
    }

	void OnTriggerEnter(Collider other)
	{      
		if (other.gameObject.CompareTag("Player"))
        {

			rb.transform.Translate(Vector3.down * Time.deltaTime);
        }

    }
}
