using UnityEngine;

public class ObjectRepulsion : ObjectBehaviour {
	public override void Activate(Rigidbody other) {
		if (other.velocity.magnitude < minimumForceToActivate) return;

		Rigidbody rb = GetComponent<Rigidbody>();
		
		rb.AddForce((other.position - rb.position).normalized * other.velocity.magnitude, ForceMode.Impulse);
	}
}
