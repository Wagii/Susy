using System.Collections.Generic;
using UnityEngine;

public class ObjectKinematic : ObjectBehaviour {
	private List<Rigidbody> list;
	
	protected void Awake() {
		list = new List<Rigidbody>(0);
	}
	
	public override void Activate(Collision collision) {
		if (collision.relativeVelocity.magnitude < minimumForceToActivate) return;
		collision.rigidbody.isKinematic = true;
		collision.rigidbody.velocity = Vector3.zero;
		list.Add(collision.rigidbody);
	}

	public void LiberaMe() {
		if (list.Count == 0) return;
		foreach (var item in list) {
			item.isKinematic = false;
		}
		list = new List<Rigidbody>(0);
	}
}
