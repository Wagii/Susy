using UnityEngine;

public class Direction : MonoBehaviour {
	[SerializeField] private Transform pos = null;
	[SerializeField] private Transform target = null;
	[SerializeField] private Gradient colorGradiant = null;
	[SerializeField] private float maxDistance = 100f;
	
	private Renderer rd = null;

	protected void Awake () {
		this.rd = GetComponent<Renderer>();
		if (target == null) {
			Destroy(this);
			return;
		}
	}
	
	protected void FixedUpdate() {
		this.transform.position = this.pos.position;
		
		if (this.target == null) {
			this.rd.enabled = false;
			return;
		}
		else 
			this.transform.LookAt(this.target);
			
		this.rd.materials[0].color = colorGradiant.Evaluate((this.target.position - this.transform.position).magnitude/maxDistance);
	}
	
	public void SetNewTarget (Transform newTarget) {
		this.target = newTarget;
	}
}
