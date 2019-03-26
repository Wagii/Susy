/*
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class CollisionSound : MonoBehaviour {

	[HideInInspector] public bool useManagerSounds = true;
	private EventInstance playerSound, objectSound;

	public List<Sounds> sounds;
	private List<EventInstance> instances;
	
	protected void Awake () {
		var tra = transform;
		var rb = GetComponent<Rigidbody>();
		if (rb == null) return;
		if (this.sounds.Count == 0) {
			this.playerSound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.player_collision_sound);
			RuntimeManager.AttachInstanceToGameObject(this.playerSound, tra, rb);
			this.objectSound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.object_collision_sound);
			RuntimeManager.AttachInstanceToGameObject(this.objectSound, tra, rb);
		} else {
			this.instances = new List<EventInstance>(this.sounds.Count);
			for (int i = 0; i < this.sounds.Count; i++) {
				this.instances.Add(RuntimeManager.CreateInstance(this.sounds[i].eventRef));
				RuntimeManager.AttachInstanceToGameObject(this.instances[i], tra, rb);
				this.instances[i].setVolume(this.sounds[i].soundVolume);
			}
		}
	}
	
	protected void OnCollisionEnter(Collision collisionInfo) {
		for (int i = 0; i < sounds.Count; i++) {
			if (collisionInfo.relativeVelocity.magnitude < this.sounds[i].minimumValueToActivate) continue;
			
			if (collisionInfo.other.tag.Contains(this.sounds[i].collisionTag) == false && this.sounds[i].collisionTag != null) continue;
			this.instances[i].setVolume(this.sounds[i].soundVolume);
			this.instances[i].start();
		}
	}
	
	protected void OnDestroy()
	{
		StopAllPlayerEvents();
		for (int i = 0; i < instances.Count; i++) {
			instances[i].release();
		}
	}
	
	private void StopAllPlayerEvents()
	{
		FMOD.Studio.Bus playerBus = FMODUnity.RuntimeManager.GetBus("bus:/player");
		playerBus.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
*/