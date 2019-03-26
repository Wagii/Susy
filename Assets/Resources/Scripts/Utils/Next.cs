using UnityEngine;

public struct Next {
	public Vector3 position { get { return this.checkpoint.transform.position; } }
	public float validationRange { get { return this.checkpoint.validationRange; } }
	public float percentTimeAdd { get { return this.checkpoint.percentTimeAdd; } }
	
	public Checkpoint checkpoint;
	public int number;
}
