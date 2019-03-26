using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAtPosition : MonoBehaviour
{
	[SerializeField] private Transform target = null;
	[SerializeField] private bool pointNorth = false;
	[SerializeField] private Transform lookAtTarget = null;

	protected void FixedUpdate() {
		if (target == null) {
			Destroy(this);
			return;
		}
		
		this.transform.position = this.target.position;
		
		if (pointNorth) {
			this.transform.forward = Vector3.forward;
			return;
		}
		
		if (lookAtTarget == null) {
			GetComponent<Renderer>().enabled = false;
			return;
		}
		else 
			this.transform.LookAt(lookAtTarget);
	}
    
	public void SetNewTarget (Transform newTarget) {
		lookAtTarget = newTarget;
	}
}