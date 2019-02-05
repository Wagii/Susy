using UnityEngine;

[CreateAssetMenu(fileName = "Movement Parameters", menuName = "Susy/MovementParameters", order = 1)]
public class MovementParameters : ScriptableObject {
	public bool reverse = true;
	public bool rotate = false;
	public float speedMultiplier = 1;
	//public AnimationCurve speedMultiplier;
	public float angularSpeedMultiplier = 1;
	//public AnimationCurve angularSpeedMultiplier;
	//public bool angularSpeed;
	public uint angleSnapThreshold = 5;
}
