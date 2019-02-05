using UnityEngine;

public class GrabTrigger : MonoBehaviour {
	[SerializeField] private SphereCollider trigger;
	[SerializeField] private float minimumSpeedToActivate = 3;
	[SerializeField] private AnimationCurve triggerSizeByTime;
	private Transform tra;
	private Rigidbody rb;
	
	
	protected void Start() {
		if (this.trigger == null) {
			DestroyImmediate(this);
			return;
		}
		this.tra = transform;
		this.rb = Manager.player;
	}
	
	protected void Update() {
		if (this.rb.velocity.magnitude < minimumSpeedToActivate && this.trigger.enabled == true) {
			this.trigger.enabled = false;
			return;
		}
		if (this.trigger.enabled == false) this.trigger.enabled = true;
		this.trigger.radius = this.triggerSizeByTime.Evaluate(this.rb.velocity.magnitude);
	}
	
	protected void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (rb == null) return;
		rb.AddForce((this.tra.position - rb.position).normalized * rb.velocity.magnitude);
	}
	
	protected void OnEnable() {
		this.trigger.enabled = false;
	}
}
