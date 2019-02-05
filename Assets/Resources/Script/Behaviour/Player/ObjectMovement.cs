using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ObjectMovement : MonoBehaviour {

	private const int playerLayer = 8;
	
	private Vector3 pressPosition;
	private Vector3 actualPosition { get { return this.objRb.position; } }

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device controller { get {return SteamVR_Controller.Input((int) trackedObject.index); } }
	private EVRButtonId buttonId;
	
	private Rigidbody objRb;
	private Transform tra;
	private ObjectParameters parameters { get { return Manager.manager.objectParameter; } }
	//private Rigidbody rb;

	private Hands hand;
	
	//private Handler arrow;

	protected void Awake() {
		this.trackedObject = GetComponent<SteamVR_TrackedObject>();
		this.buttonId = EVRButtonId.k_EButton_SteamVR_Touchpad;
		this.tra = transform;
	}
	
	protected void Start() {
		this.hand = (Manager.left.controller == gameObject)? Manager.left : Manager.right;
	}

	protected void Update() {

		if (this.controller.GetPressUp(this.buttonId)) {
			if (this.objRb == null) return;
			
			if (this.objRb.IsSleeping()) this.objRb.WakeUp();
			
			Vector3 dir = this.tra.position - this.pressPosition;
			//this.objRb.AddForce(dir * this.parameters.speedMultiplier * ((this.parameters.reverse)? -1 : 1), ForceMode.Impulse);
			this.objRb.velocity = dir * this.parameters.speedMultiplier * ((this.parameters.reverse)? -1: 1);
			this.pressPosition = Vector3.zero;
			this.objRb = null;
			//this.arrow.DestroyHand();
			Handler.DisableHand(hand.objectHand);
			//this.arrow = null;
			ObjectThrowSound.Play();
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
				
				this.pressPosition = this.objRb.position;
				//this.arrow = Handler.CreateHand(this.pressPosition, null, this.tra, Manager.manager.objectParameter.reverse);
				Handler.ActivateHand(hand.objectHand, this.objRb.transform);
				ObjectGrabSound.Play();
			}
		}
	}
}
