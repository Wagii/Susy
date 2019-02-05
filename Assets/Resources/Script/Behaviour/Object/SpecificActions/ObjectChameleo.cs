using UnityEngine;

public class ObjectChameleo : ObjectBehaviour {
	private ObjectBehaviour newBehaviour;
	
	private Material originColor;
	[HideInInspector] public bool transformed { get; private set; }
	
	public float splatRange = 5.0f;
	
	protected void Awake() {
		this.originColor = this.GetComponent<Renderer>().material;
	}
	
	private bool CheckCopy (Collision collision) {
		if (collision.gameObject.GetComponent<Renderer>() == null) return false;
		if (collision.gameObject.GetComponent<ObjectBehaviour>() == null) return false;
		if (collision.gameObject.GetComponent<ObjectChameleo>() != null)
			if (collision.gameObject.GetComponent<ObjectChameleo>().transformed == false) 
				return false;
		return true;
	}
	
	private void Copy (GameObject other) {
		this.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
		this.newBehaviour = other.GetComponent<ObjectBehaviour>();
		this.transformed = true;
	}
	
	public override void Activate(Collision collision) {
		if (collision.relativeVelocity.magnitude < minimumForceToActivate) return;
		if (CheckCopy(collision) == false) return;
		if (this.transformed == true) {
			this.newBehaviour.Activate(collision);
}
		
		Copy(collision.gameObject);
	}
	
	public void Splat () {
		Collider[] cols = Physics.OverlapSphere(this.transform.position, this.splatRange);
		if (cols.Length < 1) return;
		
		foreach (var item in cols) {
			
		}
	}
}
