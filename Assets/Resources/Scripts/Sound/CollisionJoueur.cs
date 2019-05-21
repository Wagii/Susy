using UnityEngine;
using FMODUnity;

public class CollisionJoueur : MonoBehaviour {
    
	public Camera cam;
	private FMOD.Studio.EventInstance sound;
	private FMOD.Studio.EventInstance colisSound;
	private LoseColisOnCollision lcoc = null;
    
	protected void Start() {
		this.sound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.player_collision_sound);
		RuntimeManager.AttachInstanceToGameObject(this.sound, cam.transform, Manager.player);
		this.colisSound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.loseColis);
		RuntimeManager.AttachInstanceToGameObject(this.colisSound, cam.transform, Manager.player);
		lcoc = GetComponent<LoseColisOnCollision>();
	}
    
	protected void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.relativeVelocity.magnitude < Manager.parameters.soundParameters.minimumCollisionForce) return;
		
		this.sound.setVolume(Mathf.Clamp01(collisionInfo.relativeVelocity.magnitude/Manager.parameters.soundParameters.playerCollisionVolumeDivider));
		this.sound.start();
	}
	
	public void PlayLose() {
		this.colisSound.start();
	}
}
