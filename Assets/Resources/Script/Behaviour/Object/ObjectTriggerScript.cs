using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class ObjectTriggerScript : MonoBehaviour {
	
	public float minimumSpeedToActivate = 1;
	public TriggerEvent playerTrigger;
	public TriggerEvent objectTrigger;
	
	protected void Start() {
		SphereCollider collider = gameObject.AddComponent<SphereCollider>();
		collider.isTrigger = true;
		collider.center = Vector3.zero;
		collider.radius = Manager.manager.objectParameter.triggerRadius;
	}
	
	protected void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (other.GetComponent<SteamVR_Camera>() != null)
			rb = Manager.player;

		if (rb == null) return;
		if (rb.velocity.magnitude < minimumSpeedToActivate) return;
		
		if (other.GetComponent<SteamVR_ControllerManager>() != null) {
			playerTrigger.Invoke(rb);
		} else {
			objectTrigger.Invoke(rb);
		}
	}
}

[System.Serializable]
public class TriggerEvent : UnityEvent<Rigidbody> {}