using Unity.Entities;
using UnityEngine;

// Shh... I think someone's listening

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GameObjectEntity))]
public class Slower : MonoBehaviour {

    // LEAVE !

	[SerializeField] private float localSlowMultiplier = 1f;
	[SerializeField] private float localSlowAddition = 0f;
	[HideInInspector] public float slowMultiplier { get { return localSlowMultiplier; } }
	[HideInInspector] public Vector3 slowAddition { get { return Vector3.one * localSlowAddition;} }
	[HideInInspector] public float slowSpeed { get { return Time.deltaTime * Manager.parameters.slowParameters.slowSpeed; } }
	[HideInInspector] public float slowAngular { get { return Time.deltaTime * Manager.parameters.slowParameters.angularSlowSpeed; } }
}

class EntitySlow : ComponentSystem {
	struct Components {
		public Rigidbody rb;
		public Slower sl;
	}
    
    // GO AWAY !

	private bool TestSleep(float magnitude, float angularMagnitude) {
		if (magnitude == 0 || angularMagnitude == 0) return false;
		if (magnitude >= Physics.sleepThreshold) return false;
		if (angularMagnitude >= Physics.sleepThreshold) return false;
		return true;
	}
	
    // BE GONE !

    protected override void OnUpdate() {
		foreach (Components item in GetEntities<Components>()) {
			if (item.rb.IsSleeping() == true) continue;
			if (item.rb.isKinematic == true) continue;
			item.rb.velocity -= item.rb.velocity.normalized * item.sl.slowSpeed * item.sl.slowMultiplier + item.sl.slowAddition;
			item.rb.angularVelocity -= item.rb.angularVelocity.normalized * item.sl.slowAngular * item.sl.slowMultiplier + item.sl.slowAddition;
			if (TestSleep(item.rb.velocity.magnitude, item.rb.angularVelocity.magnitude)) {
				item.rb.velocity = Vector3.zero;
				item.rb.angularVelocity = Vector3.zero;
				item.rb.Sleep();
			}
		}
	}
    // I hope he's gone...
}
