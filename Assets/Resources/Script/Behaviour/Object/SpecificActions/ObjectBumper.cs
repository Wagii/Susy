using UnityEngine;

public class ObjectBumper : ObjectBehaviour {
	[SerializeField] private float repulsionForceMultiplier = 1.5f;
	public override void Activate(Collision collision) {
		if (collision.relativeVelocity.magnitude < minimumForceToActivate) return;
		
		this.GetComponent<Rigidbody>().velocity *= repulsionForceMultiplier;
		collision.rigidbody.velocity *= repulsionForceMultiplier;
	}

	public override void Activate(Rigidbody other) {
		this.GetComponent<Rigidbody>().velocity *= repulsionForceMultiplier;
		other.velocity *= repulsionForceMultiplier;
	}
}
