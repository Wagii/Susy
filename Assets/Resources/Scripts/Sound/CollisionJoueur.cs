using UnityEngine;
using FMODUnity;

public class CollisionJoueur : MonoBehaviour {
    
	private FMOD.Studio.EventInstance sound;
    
	protected void Start() {
		this.sound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.player_collision_sound);
		RuntimeManager.AttachInstanceToGameObject(this.sound, this.transform, Manager.player);
	}
    
	protected void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.relativeVelocity.magnitude < Manager.parameters.soundParameters.minimumCollisionForce) return;
		
		this.sound.setVolume(Mathf.Clamp01(Manager.player.velocity.magnitude/Manager.parameters.soundParameters.playerCollisionVolumeDivider));
		this.sound.start();
	}
}
