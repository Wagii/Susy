using UnityEngine;

public class Slower : MonoBehaviour {

	public Rigidbody rb { get; private set; }
	private float mass;

	protected void Awake() {
		if (this.rb == null)
			Initialize();
	}

	public void Initialize() {
		this.rb = GetComponent<Rigidbody>();
		this.mass = this.rb.mass;
		this.rb.mass = 1;
		this.rb.drag = 0;
		this.rb.angularDrag = 0;
		this.rb.useGravity = false;
	}

	public void Slow (float slowSpeedMultiplier, float angularSlowSpeedMultiplier) {
		this.rb.velocity -= this.rb.velocity * (slowSpeedMultiplier / this.mass) * Time.deltaTime;
		this.rb.angularVelocity -= this.rb.angularVelocity * (angularSlowSpeedMultiplier / this.mass) * Time.deltaTime;
	}

	public void Stop () {
		if (this.rb.IsSleeping() == false) {
			this.rb.velocity = Vector3.zero;
			this.rb.angularVelocity = Vector3.zero;
			this.rb.Sleep();
		}
	}
}
