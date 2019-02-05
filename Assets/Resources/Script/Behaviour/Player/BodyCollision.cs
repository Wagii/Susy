using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BodyCollision : MonoBehaviour {
	[SerializeField] private SphereCollider playerHeadCollision;
	[SerializeField] private float thiccness = 1;
	private CapsuleCollider col;
	private Transform tra;
	
	private Transform head { get { return playerHeadCollision.transform; } }
	
	protected void Awake() {
		if (this.playerHeadCollision == null || this.GetComponent<CapsuleCollider>() == null) {
			Destroy(this);
			return;
		}
		this.tra = this.transform;
		this.col = this.GetComponent<CapsuleCollider>();
		//this.tra.parent = this.head.parent;
		this.tra.localPosition = this.head.localPosition - Vector3.up * (this.head.localPosition.y/2);
		this.col.radius = this.thiccness;
		this.col.height = this.head.localPosition.y;
	}
	
	protected void Update() {
		this.tra.localPosition = this.head.localPosition - Vector3.up * (this.head.localPosition.y/2);
		this.col.height = this.head.localPosition.y;
	}
}
