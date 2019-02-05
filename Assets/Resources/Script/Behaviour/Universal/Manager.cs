using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public struct Hands {
	public GameObject controller;
	public GameObject movementHand;
	public GameObject objectHand;
}
	
public class Manager : MonoBehaviour {


	public static Manager manager;
	public static Rigidbody player;

	[SerializeField] private GameObject handPrefab;
	[SerializeField] private GameObject reverseHandPrefab;

	[SerializeField] private SlowParameters slowParameters;
	public MovementParameters movementParameters;
	public ColliderParameters colliderParameter;
	public ObjectParameters objectParameter;
	public SoundParameters soundParameters;

	private GameObject leftMovementHand;
	private GameObject leftObjectHand;
	private GameObject rightMovementHand;
	private GameObject rightObjectHand;

	public static Hands left;
	public static Hands right;

	private Slower[] slowers;

	protected void Awake() {
		manager = this;
		Rigidbody[] items = GameObject.FindObjectsOfType<Rigidbody>();
		List<Slower> slowers = new List<Slower>();
		foreach (var item in items)
		{
			if (item.GetComponent<Slower>() == null){
				Slower slower = item.gameObject.AddComponent<Slower>();
				slower.Initialize();
				slowers.Add(slower);
			}
		}
		this.slowers = new Slower[slowers.Count];
		slowers.CopyTo(this.slowers);
		player = GameObject.FindObjectOfType<SteamVR_ControllerManager>().GetComponent<Rigidbody>();
		//Handler.prefab = this.handPrefab;
		//Handler.reversePrefab = this.reverseHandPrefab;
		if (this.movementParameters.reverse) {
			leftMovementHand = Instantiate(reverseHandPrefab, Vector3.zero, Quaternion.identity, player.transform);
			rightMovementHand = Instantiate(reverseHandPrefab, Vector3.zero, Quaternion.identity, player.transform);
		} else {
			leftMovementHand = Instantiate(handPrefab, Vector3.zero, Quaternion.identity, player.transform);
			rightMovementHand = Instantiate(handPrefab, Vector3.zero, Quaternion.identity, player.transform);
		}
		if (this.objectParameter.reverse) {
			leftObjectHand = Instantiate(reverseHandPrefab, Vector3.zero, Quaternion.identity, player.transform);
			rightObjectHand = Instantiate(reverseHandPrefab, Vector3.zero, Quaternion.identity, player.transform);
		} else {
			leftObjectHand = Instantiate(handPrefab, Vector3.zero, Quaternion.identity, player.transform);
			rightObjectHand = Instantiate(handPrefab, Vector3.zero, Quaternion.identity, player.transform);
		}
		SteamVR_ControllerManager controllerManager = player.GetComponent<SteamVR_ControllerManager>();
		Handler.CreateHand(leftMovementHand, controllerManager.left.transform, movementParameters.reverse);
		Handler.CreateHand(leftObjectHand, controllerManager.left.transform, objectParameter.reverse);
		Handler.CreateHand(rightMovementHand, controllerManager.right.transform, movementParameters.reverse);
		Handler.CreateHand(rightObjectHand, controllerManager.right.transform, objectParameter.reverse);
		left.controller = controllerManager.left;
		left.movementHand = leftMovementHand;
		left.objectHand = leftObjectHand;
		right.controller = controllerManager.right;
		right.movementHand = rightMovementHand;
		right.objectHand = rightObjectHand;
	}

	protected void Update () {
		if (this.slowers.Length != 0)
		foreach (var item in slowers)
		{
			if (item.rb.velocity.magnitude >= this.slowParameters.slowSpeedSnap || item.rb.angularVelocity.magnitude >= this.slowParameters.angularSpeedSnap)
				item.Slow(this.slowParameters.slowSpeedMultiplier, this.slowParameters.angularSlowSpeedMultiplier);
			else
				item.Stop();
		}
	}
}
