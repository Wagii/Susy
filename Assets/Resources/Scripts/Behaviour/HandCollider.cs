using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class HandCollider : MonoBehaviour
{
	private Rigidbody rb;

	protected void Awake() {
		this.rb = GetComponent<Rigidbody>();
	}
	
	public void UpdatePosition (Valve.VR.SteamVR_Behaviour_Pose pose, Valve.VR.SteamVR_Input_Sources sources) {
		this.rb.MovePosition(pose.poseAction.localPosition);
	}
}
