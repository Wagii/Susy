using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAtPosition : MonoBehaviour
{
	[SerializeField] private Transform target;

	protected void FixedUpdate() {
		if (target == null) {
			Destroy(this);
			return;
		}
		
		this.transform.position = this.target.position;
    }
}
