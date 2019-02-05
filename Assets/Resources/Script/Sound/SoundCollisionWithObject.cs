using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundCollisionWithObject : MonoBehaviour {

	private FMOD.Studio.EventInstance music_fmod;

	private Transform tra;
	private Rigidbody rb;

	protected void Start () {
		this.tra = transform;
		this.rb = GetComponent<Rigidbody>();
		this.music_fmod = RuntimeManager.CreateInstance(Manager.manager.soundParameters.object_collision_sound);
	}
	
	protected void Update () {
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod, this.tra, this.rb);
	}
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.impactForceSum.magnitude < Manager.manager.soundParameters.minimumCollisionForce) return;
		if (collisionInfo.gameObject.GetComponent<SteamVR_Camera>() == true) return;
		
		this.music_fmod.setVolume(Manager.manager.soundParameters.objectCollisionVolume);
		this.music_fmod.start();
	}
}
