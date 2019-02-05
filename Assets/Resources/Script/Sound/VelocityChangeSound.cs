using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActions : MonoBehaviour {
	
	// public FMOD sound;
	[FMODUnity.EventRef] public string vent_state;
	private FMOD.Studio.EventInstance vent_fmod;
	
	[Range(0, 1)] private float volume;
	[SerializeField] private AnimationCurve volumeOverTime;
	
	private Rigidbody rb;
	private Vector3 lastVelocity;
	
	protected void Awake() {
		this.rb = GetComponent<Rigidbody>();
		vent_fmod = FMODUnity.RuntimeManager.CreateInstance(vent_state);
	}
	
	protected void Update () {
		if (this.rb == null) return;
		if (this.lastVelocity.magnitude >= this.rb.velocity.magnitude) {
			this.lastVelocity = this.rb.velocity;
			return;
		}
		else
			this.lastVelocity = this.rb.velocity;
		
		EventVelocityChange((this.rb.velocity - this.lastVelocity).magnitude);
	}
	
	private void EventVelocityChange ( float velocityChangeValue /*, Place parameters maybe */ ) {
		// FixedVolume(this.volume);
		StartCoroutine(VolumeOverTime(this.volumeOverTime));
	}
	
	private void FixedVolume(float volume) {
		// this.sound.PLAY();
		// this.sound.SETVOLUME(volume);
	}
	
	private IEnumerator VolumeOverTime (AnimationCurve curve) {
		// this.sound.PLAY();
		for (float f = 0; f < curve.length; f += Time.deltaTime) {
			// this.sound.VOLUME = curve.Evaluate(f);
			yield return null;
		}
	}
}
