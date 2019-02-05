using UnityEngine;

[CreateAssetMenu(fileName = "Object Parameters", menuName = "Susy/ObjectParameter", order = 2)]
public class ObjectParameters : ScriptableObject {
	public bool reverse = true;
	public bool rotate = false;
	public float speedMultiplier = 1;
	//public AnimationCurve speedMultiplier;
	public float angularSpeedMultiplier = 1;
	//public AnimationCurve angularSpeedMultiplier;
	//public bool angularSpeed;
	public uint angleSnapThreshold = 5;
	public float grabRadius = .1f;
	public float triggerRadius = 1;
}
