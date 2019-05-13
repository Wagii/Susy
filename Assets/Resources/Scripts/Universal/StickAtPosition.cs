using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAtPosition : MonoBehaviour
{
	public Transform target = null;
	[SerializeField] private bool pointNorth = false;

	protected void Update() {
		if (target == null) {
			Destroy(this);
			return;
		}
		
		this.transform.position = this.target.position;
		
		if (pointNorth) {
			this.transform.forward = Vector3.forward;
			return;
		}
	}
}