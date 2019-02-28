using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BodyCollision : MonoBehaviour {
	[SerializeField] private SphereCollider playerHeadCollider;
	[SerializeField] private float radius = 1;
	private CapsuleCollider col;
	private Transform tra;
	
	private Transform head { get { return playerHeadCollider.transform; } }
	
	protected void Awake() {
		if (this.playerHeadCollider == null || this.GetComponent<CapsuleCollider>() == null) {
			Destroy(this);
			return;
		}
		this.tra = this.transform;
		this.col = this.GetComponent<CapsuleCollider>();
		this.tra.localPosition = this.head.localPosition - Vector3.up * (this.head.localPosition.y/2);
		this.col.radius = this.radius;
		this.col.height = this.head.localPosition.y;
	}
	
	protected void FixedUpdate() {
		this.col.center = this.head.localPosition - Vector3.up * (this.head.localPosition.y/2);
		this.col.height = this.head.localPosition.y;
	}
}
