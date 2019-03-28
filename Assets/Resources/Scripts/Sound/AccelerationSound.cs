using UnityEngine;
using FMODUnity;

public class AccelerationSound : MonoBehaviour {
    
	private FMOD.Studio.EventInstance sound;
	private float speed = 0;
	[SerializeField] private float crescendoSpeed = 3f, descrecendoSpeed = 1f;
    
	private float playerSpeed { get { return Manager.player.velocity.magnitude; } }
    
	protected void Start() {
		this.sound = RuntimeManager.CreateInstance(Manager.parameters.soundParameters.player_acceleration_sound);
		RuntimeManager.AttachInstanceToGameObject(this.sound, this.transform, Manager.player);
		this.sound.setParameterValue("speed", 0);
		this.sound.start();
	}
    
	protected void Update() {
		this.speed = Mathf.Clamp01(GoodEnough.Lerp(this.speed, playerSpeed, (this.speed < playerSpeed)? this.crescendoSpeed : this.descrecendoSpeed)/Manager.parameters.soundParameters.playerAccelerationVolumeDivider);
		
		this.sound.setParameterValue("speed", this.speed);
	}
}
