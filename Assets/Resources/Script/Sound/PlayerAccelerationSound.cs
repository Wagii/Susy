using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerAccelerationSound : MonoBehaviour {

	public static PlayerAccelerationSound player;
	public static void PlaySound() {
		player.music_fmod.setVolume(Manager.manager.soundParameters.playerAccelerationVolume);
		player.music_fmod.start();
	}

	public FMOD.Studio.EventInstance music_fmod;

	private Transform tra;
	private Rigidbody rb;

	protected void Awake() {
		player = this;
	}

	protected void Start () {
		this.tra = transform;
		this.rb = GetComponent<Rigidbody>();
		this.music_fmod = RuntimeManager.CreateInstance(Manager.manager.soundParameters.player_acceleration_sound);
	}

	protected void Update () {
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod, this.tra, this.rb);
	}
}
