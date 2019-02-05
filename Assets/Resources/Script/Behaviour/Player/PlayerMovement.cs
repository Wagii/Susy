using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PlayerMovement : MonoBehaviour {

	private Transform tra;
	private Rigidbody rb;
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device controller { get {return SteamVR_Controller.Input((int) trackedObject.index); } }
	private EVRButtonId buttonId;

	private Vector3 pressPosition;
	private Vector3 actualPosition { get { return this.tra.localPosition; } }

	private MovementParameters parameters { get { return Manager.manager.movementParameters; } }
	
	private Hands hand;
	
	//private Handler arrow;

	protected void Awake() {
		this.trackedObject = GetComponent<SteamVR_TrackedObject>();
		buttonId = EVRButtonId.k_EButton_SteamVR_Trigger;
		this.tra = transform;
	}

	protected void Start() {
		this.rb = Manager.player;
		this.hand = (Manager.left.controller == gameObject)? Manager.left : Manager.right;
	}

	protected void Update() {

		if (controller.GetPressUp(buttonId)) {
			if (this.rb.IsSleeping()) this.rb.WakeUp();
			Vector3 dir = pressPosition - actualPosition;
			this.rb.AddForce(dir * this.parameters.speedMultiplier * (this.parameters.reverse? 1 : -1), ForceMode.Impulse);
			this.rb.velocity = dir;

			if (dir.magnitude > Manager.manager.soundParameters.playerMinimumAcceleration)
				PlayerAccelerationSound.PlaySound();
				
			//this.arrow.DestroyHand();
			Handler.DisableHand(this.hand.movementHand);
			//this.arrow = null;
		}

		if (controller.GetPressDown(buttonId)) {
			this.pressPosition = this.tra.localPosition;
			//this.arrow = Handler.CreateHand(this.pressPosition, Manager.player.transform, this.tra, Manager.manager.movementParameters.reverse);
			Handler.ActivateHand(hand.movementHand, this.tra);
		}
	}
}
