using UnityEngine;

[CreateAssetMenu(fileName = "Player Movement Parameters", menuName = "Susy/PlayerMovementParameters")]
public class PlayerMovementParameters : ScriptableObject
{
	[Header("Minimum Size of a drawn vector")] public float minVectorValue = .1f;
	[Header("Maximum Size of a drawn vector")] public float maxVectorValue = 5f;
	[Header("Ratio Size -> Speed")] public float playerSpeedMultiplier = 1f;
	[Range(0,180f)][Header("Minimum angle between vector and speed direction to activate stop")] public float stopAngleThreshold = 150f;
	[Header("Stopping power (speed = 1 - stop power)")] public AnimationCurve stopPower = null;
	[Space][Space][Space]
	public bool add = true;
	public bool reverse = false;
}
