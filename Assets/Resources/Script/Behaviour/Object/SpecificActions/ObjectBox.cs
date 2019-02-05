using System.Collections.Generic;
using UnityEngine;

public class ObjectBox : ObjectBehaviour {
	private List<GameObject> list;
	
	protected void Awake() {
		list = new List<GameObject>(0);
	}
	
	public override void Activate(Collision collision) {
		if (collision.relativeVelocity.magnitude < minimumForceToActivate) return;
		list.Add(collision.gameObject);
		collision.gameObject.SetActive(false);
	}

	public void LiberaMe() {
		if (list.Count == 0) return;
		Vector3 position = this.transform.position;
		foreach (var item in list) {
			item.SetActive(true);
			item.transform.position = position;
		}
		list = new List<GameObject>(0);
	}
}
