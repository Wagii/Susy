using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class ObjectGrabSound : MonoBehaviour {
	public static ObjectGrabSound instance;
	
	private FMOD.Studio.EventInstance music_fmod;

	private Transform tra;
	private Rigidbody rb;

	protected void Start () {
		this.tra = transform;
		this.rb = GetComponent<Rigidbody>();
		this.music_fmod = RuntimeManager.CreateInstance(Manager.manager.soundParameters.objectGrabSound);
		ObjectGrabSound.instance = this;
	}
	
	protected void Update () {
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod, this.tra, this.rb);
	}
	
	public static void Play () {
		ObjectGrabSound.instance.StartSound ();
	}
	
	protected void StartSound () {
		this.music_fmod.setVolume(Manager.manager.soundParameters.objectGrabVolume);
		this.music_fmod.start();
	}
}
