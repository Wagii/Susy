using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CantGoFartherFromThere : MonoBehaviour {

	[SerializeField] public Vector3 center;
	[SerializeField] public float bounds = 10000f;
	[SerializeField] private float pullForceGrowingSpeed = 5f;
	
	private Rigidbody rb = null;
	private float timer = 0;
	
	protected void Awake() {
		this.rb = this.GetComponent<Rigidbody>();
	}
	
	private void Update () {
		if (Vector3.Distance(this.transform.position, center) >= bounds) {
			this.timer += Time.deltaTime * this.pullForceGrowingSpeed;
			this.rb.velocity += (this.center - this.transform.position).normalized * this.timer;
		} else
			timer = 0;
		
	}
}
