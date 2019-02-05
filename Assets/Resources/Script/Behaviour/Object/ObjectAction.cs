using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAction : MonoBehaviour {
	public void Repulse (Rigidbody other) {
		Rigidbody rb = GetComponent<Rigidbody>();
		
		rb.AddForce((rb.position - other.position).normalized * other.velocity.magnitude, ForceMode.Impulse);
	}
	
	public void Attract (Rigidbody other) {
		Rigidbody rb = GetComponent<Rigidbody>();
		
		rb.AddForce((other.position - rb.position).normalized * other.velocity.magnitude, ForceMode.Impulse);
	}
}
