using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed = 5.0f;
	Vector3 m_direction;
	bool m_fired;
	GameObject m_launcher;
	GameObject m_target;
	int m_damage;


	// Update is called once per frame
	void Update () {
		if(m_fired){
			transform.position += m_direction * (speed * Time.deltaTime);
		}}

	public void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed){
		if(launcher && target){
			m_direction = (target.transform.position - launcher.transform.position).normalized;
			m_fired = true;
			m_launcher = launcher;
			m_target = target;
			m_damage = damage;
			 
			Destroy(gameObject, 10.0f);
		}
	}


	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject == m_target) {
			// si la cible est le joueur => perdu
		}
		 
	}

}
	
