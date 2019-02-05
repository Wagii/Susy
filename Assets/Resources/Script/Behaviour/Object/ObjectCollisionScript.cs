using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class ObjectCollisionScript : MonoBehaviour {

	public RigidbodyEvent onCollisionWithPlayer;
	public RigidbodyEvent onCollisionWithObject;
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		Rigidbody rb = collisionInfo.rigidbody;
		if (rb == null) return;
		
		
		if (collisionInfo.gameObject.GetComponent<SteamVR_ControllerManager>() != null) {
			this.onCollisionWithPlayer.Invoke(collisionInfo);
		}
		else if (collisionInfo.gameObject.GetComponent<Rigidbody>() != null) {
			this.onCollisionWithObject.Invoke(collisionInfo);
		}
	}
}

[System.Serializable]
public class RigidbodyEvent : UnityEvent<Collision> {}