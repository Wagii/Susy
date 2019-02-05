 using UnityEngine;
 using Valve.VR;

 [RequireComponent(typeof(SteamVR_TrackedObject))]
 public class ObjectRotate : MonoBehaviour {

 	private const int playerLayer = 8;
	
 	private Quaternion pressRotation;
 	private Quaternion actualRotation { get { return this.objRb.rotation; } }

 	private SteamVR_TrackedObject trackedObject;
 	private SteamVR_Controller.Device controller { get {return SteamVR_Controller.Input((int) trackedObject.index); } }
 	private EVRButtonId buttonId;
	
 	private Rigidbody objRb;
 	private Transform tra;
 	private ObjectParameters parameters { get { return Manager.manager.objectParameter; } }
 	//private Rigidbody rb;


 	protected void Awake() {
 		this.trackedObject = GetComponent<SteamVR_TrackedObject>();
 		this.buttonId = EVRButtonId.k_EButton_SteamVR_Touchpad;
 		this.tra = transform;
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

 		if (this.controller.GetPressUp(this.buttonId)) {
 			if (this.objRb == null) return;
			
 			if (this.objRb.IsSleeping()) this.objRb.WakeUp();
 			Vector3 rot = snapToAngleIfTooCloseOf360((Quaternion.Inverse(this.pressRotation) * this.actualRotation).eulerAngles);
 			this.objRb.AddTorque(
 				rot.x * Vector3.right +
 				rot.y * Vector3.up +
 				rot.z * Vector3.forward, ForceMode.Impulse);
 			this.pressRotation = Quaternion.identity;
 			this.objRb = null;
 		}

 		if (this.controller.GetPressDown(this.buttonId)) {
 			Collider[] cols;
 			if (Extension.OverlapSphereNonAlloc(this.tra.position, Manager.manager.objectParameter.grabRadius, out cols, ~(1<<playerLayer)) > 0) {
 				foreach (var item in cols) {
 					if (item.GetComponent<Rigidbody>()) {
 						this.objRb = item.GetComponent<Rigidbody>();
 						break;
 					}
 				}
 				if (this.objRb == null) return;
				
 				this.pressRotation = this.actualRotation;
 			}
 		}
 	}
 }
