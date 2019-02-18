using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour {

	public int index;
	public float radius;
	public float explosionForce;


	void Update () {
		
		if(Input.GetKey(KeyCode.Space)){
			Explosion();
		}

	}

	public void Explosion(){

	Collider [] colliders = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider near in colliders)
		{
			Rigidbody rigid = near.GetComponent<Rigidbody>();
			if(rigid != null){
				rigid.AddExplosionForce(explosionForce, transform.position, radius, 0);
				 //rigid.AddForce(transform.position * explosionForce);
				 rigid.transform.rotation = Quaternion.LookRotation(rigid.velocity);
			}
			
		}

	}
}
