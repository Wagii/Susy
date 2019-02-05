using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ObjectThrowSound : MonoBehaviour {
	public static ObjectThrowSound instance;
	
	private FMOD.Studio.EventInstance music_fmod;

	private Transform tra;
	private Rigidbody rb;

	protected void Start () {
		this.tra = transform;
		this.rb = GetComponent<Rigidbody>();
		this.music_fmod = RuntimeManager.CreateInstance(Manager.manager.soundParameters.objectThrowSound);
		ObjectThrowSound.instance = this;
	}
	
	protected void Update () {
		RuntimeManager.AttachInstanceToGameObject(this.music_fmod, this.tra, this.rb);
	}
	
	public static void Play () {
		ObjectThrowSound.instance.StartSound ();
	}
	
	protected void StartSound () {
		this.music_fmod.setVolume(Manager.manager.soundParameters.objectThrowVolume);
		this.music_fmod.start();
	}

}
