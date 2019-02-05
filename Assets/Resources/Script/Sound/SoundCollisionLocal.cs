using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SoundCollisionLocal : MonoBehaviour {

	[FMODUnity.EventRef] public string collisionSoundObject; 
	private FMOD.Studio.EventInstance music_fmod_object;

	[FMODUnity.EventRef] public string collisionSoundPlayer; 
	private FMOD.Studio.EventInstance music_fmod_player;
	
	[SerializeField] private float volume = 1;

	private Transform tra;
	private Rigidbody rb;

	protected void Start () {
		this.tra = transform;
		this.rb = GetComponent<Rigidbody>();
		this.music_fmod_object = RuntimeManager.CreateInstance(this.collisionSoundObject);
		this.music_fmod_player = RuntimeManager.CreateInstance(this.collisionSoundPlayer);
	}
	
	protected void Update () {
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod_object, this.tra, this.rb);
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod_player, this.tra, this.rb);
	}
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		//if (collisionInfo.relativeVelocity.magnitude < Manager.manager.soundParameters.minimumCollisionForce) return;
		if (collisionInfo.gameObject.GetComponent<SteamVR_Camera>() == null) {
			this.music_fmod_object.setVolume(this.volume);
			this.music_fmod_object.start();
		} else {
			this.music_fmod_player.setVolume(this.volume);
			this.music_fmod_player.start();
		}
	}
}
