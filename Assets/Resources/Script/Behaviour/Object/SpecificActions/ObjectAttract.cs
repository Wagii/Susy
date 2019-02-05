using UnityEngine;

public class ObjectAttract : ObjectBehaviour {
	public override void Activate(Rigidbody other) {
		if (other.velocity.magnitude < minimumForceToActivate) return;
		Rigidbody rb = GetComponent<Rigidbody>();
		
		rb.AddForce((rb.position - other.position).normalized * other.velocity.magnitude, ForceMode.Impulse);
		//rb.velocity = (other.position - rb.position).normalized * other.velocity.magnitude;
	}
}
