using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundCollisionPlayer : MonoBehaviour {

	private FMOD.Studio.EventInstance music_fmod;

	private Transform tra;
	private Rigidbody rb;

	protected void Start () {
		this.tra = transform;
		this.rb = GetComponent<Rigidbody>();
		this.music_fmod = RuntimeManager.CreateInstance(Manager.manager.soundParameters.player_collision_sound);
	}
	
	protected void Update () {
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod, this.tra, this.rb);
	}
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		//if (collisionInfo.impactForceSum.magnitude < Manager.manager.soundParameters.minimumCollisionForce) return;
		
		this.music_fmod.setVolume(Manager.manager.soundParameters.playerCollisionVolume);
		this.music_fmod.start();
	}
}
