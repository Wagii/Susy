using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GameObjectEntity))]
public class Slower : MonoBehaviour {

}

class EntitySlow : ComponentSystem {
	struct Components {
		public Rigidbody rb;
		public Slower sl;
	}
	
	protected override void OnUpdate() {
		struct Components {
			public Rigidbody rb;
			public ThrowObject to;
		}
	}
	
	private bool TestSleep(float magnitude, float angularMagnitude) {
		if (magnitude == 0 || angularMagnitude == 0) return false;
		if (magnitude >= Physics.sleepThreshold) return false;
		if (angularMagnitude >= Physics.sleepThreshold) return false;
		return true;
	}
	
	protected override void OnUpdate() {
		foreach (Components item in GetEntities<Components>()) {
			if (item.rb.IsSleeping() == true) continue;
			if (item.rb.isKinematic == true) continue;
			item.rb.velocity -= item.rb.velocity * Time.deltaTime/* * Manager.slowParameters.slowSpeed*/;
			if (TestSleep(item.rb.velocity.magnitude, item.rb.angularVelocity.magnitude)) {
				item.rb.velocity = Vector3.zero;
				item.rb.angularVelocity = Vector3.zero;
				item.rb.Sleep();
			}
		}
	}
}
