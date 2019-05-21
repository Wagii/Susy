using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "Sound Parameters", menuName = "Susy/SoundParameters")]
public class SoundParameters : ScriptableObject {
	public float minimumCollisionForce = 0f;
	[EventRef] public string player_collision_sound;
	public float playerCollisionVolumeDivider = 25f;
	[Space][Space]
	[EventRef] public string object_collision_sound;
	[Range(0,1)]public float objectCollisionVolume = 1f;
	[EventRef] public string sillageSound;
	[Space][Space]
	[EventRef] public string player_acceleration_sound;
	public float playerMinimumAcceleration = 1f;
	public float playerAccelerationVolumeDivider = 25f;
	[Space][Space]
	[EventRef] public string objectif_manager;
	public AnimationCurve dist = null;
	[EventRef] public string tenSeconds;
	[EventRef] public string loseQuest;
	[Space][Space]
	[EventRef] public string ambiance1;
	[Space][Space]
	[EventRef] public string loseColis;
	[EventRef] public string loseColisAlarm;
}