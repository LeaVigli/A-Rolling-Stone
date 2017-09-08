using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_monde3 : MonoBehaviour {

	public GameObject aDetruire;
	public GameObject arbre;
		

		void OnCollisionEnter(Collision collision)
		{
			if(collision.gameObject.tag == "interrupteur")
			{
					Destroy(aDetruire);
			}

			if (collision.gameObject.tag == "arbre") {
				// faire animation neige
				// voire remplacer l'arbre enneigé par sa version sans neige

			}

		if (collision.gameObject.tag == "bonusTemps") {


		}


		}

}
