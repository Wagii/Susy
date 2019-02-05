using UnityEngine;

public class ColliderSizeFromVelocity : MonoBehaviour {

	private float minSpeed { get { return Manager.manager.colliderParameter.minSpeed; } }
	private float maxSpeed { get { return Manager.manager.colliderParameter.maxSpeed; } }

	private Rigidbody rb;
	private SphereCollider col;
	private float speed = 0;

	protected void Start() {
		Transform tra = transform;
		this.rb = Manager.player;
		this.col = GetComponent<SphereCollider>();
	}

	protected void Update() {
		speed = Mathf.Clamp(this.rb.velocity.magnitude, minSpeed, maxSpeed);
		this.col.radius = Manager.manager.colliderParameter.colliderRadius.Evaluate(speed/maxSpeed);
	}
}
