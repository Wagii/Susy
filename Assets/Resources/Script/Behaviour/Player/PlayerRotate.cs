using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PlayerRotate : MonoBehaviour {

	private Transform tra;
	private Rigidbody rb;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device controller { get {return SteamVR_Controller.Input((int) trackedObject.index); } }
	private EVRButtonId buttonId;

	private Quaternion pressAngle;
	private Quaternion actualAngle { get { return this.tra.localRotation; } }

	private MovementParameters parameters { get { return Manager.manager.movementParameters; } }

	protected void Awake() {
		this.trackedObject = GetComponent<SteamVR_TrackedObject>();
		buttonId = EVRButtonId.k_EButton_SteamVR_Trigger;
		this.tra = transform;
	}

	protected void Start() {
		this.rb = Manager.player;
	}

	private float snapToAngleIfTooCloseOf360(float angle)
	{
		float diff = 360 - angle;
		
		if (diff <= (int)this.parameters.angleSnapThreshold || diff >= 360 - (int)this.parameters.angleSnapThreshold) return 0;
		return (angle - 180);
	}
	
	private Vector3 snapToAngleIfTooCloseOf360(Vector3 angle)
	{
		return new Vector3(
			snapToAngleIfTooCloseOf360(angle.x), 
			snapToAngleIfTooCloseOf360(angle.y), 
			snapToAngleIfTooCloseOf360(angle.z)
		);
	}

	protected void Update() {

		if (controller.GetPressUp(buttonId)) {
			if (this.rb.IsSleeping()) this.rb.WakeUp();
			if (this.parameters.rotate) {
				Vector3 euler = snapToAngleIfTooCloseOf360((Quaternion.Inverse(this.pressAngle) * this.actualAngle).eulerAngles);
				this.rb.AddTorque(euler.x * this.rb.transform.right + 
					euler.y * this.rb.transform.up + 
					euler.z * this.rb.transform.forward, 
					ForceMode.Impulse);
			}
		}

		if (controller.GetPressDown(buttonId)) {
			this.pressAngle = tra.localRotation;
		}
	}
}
