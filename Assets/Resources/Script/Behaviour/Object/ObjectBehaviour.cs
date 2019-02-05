using UnityEngine.Events;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour {
	protected RigidbodyEvent objectEvents;
	public bool trigger = false;
	
	[SerializeField] public float minimumForceToActivate = 1;
	public virtual void Activate (Collision collision) {
		
	}
	
	public virtual void Activate (Rigidbody other) {
	}
}
