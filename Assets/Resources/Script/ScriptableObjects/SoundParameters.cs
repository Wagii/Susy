using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "Sound Parameters", menuName = "Susy/SoundParameters")]
public class SoundParameters : ScriptableObject {
	public float minimumCollisionForce = 0;
	[EventRef] public string player_collision_sound;
	[Range(0,1)]public float playerCollisionVolume = 1;
	[EventRef] public string object_collision_sound;
	[Range(0,1)]public float objectCollisionVolume = 1;
	[EventRef] public string player_acceleration_sound;
	public float playerMinimumAcceleration = 1;
	[Range(0,1)]public float playerAccelerationVolume = 1;
	[EventRef] public string object_acceleration_sound;
	public float objectMinimumAcceleration = 1;
	[Range(0,1)]public float objectAccelerationVolume = 1;
	[EventRef] public string objectGrabSound;
	[Range(0,1)]public float objectGrabVolume = 1;
	[EventRef] public string objectThrowSound;
	[Range(0,1)]public float objectThrowVolume = 1;
	
}