using UnityEngine;

//[CreateAssetMenu(fileName = "Input Parameters", menuName = "Susy/InputParams", order = 0)]
public class InputParameters : ScriptableObject {
	public bool reverse = true;
	public bool rotate = false;
	public float speedMultiplier = 1;
	//public AnimationCurve speedMultiplier;
	public float angularSpeedMultiplier = 1;
	//public AnimationCurve angularSpeedMultiplier;
	//public bool angularSpeed;
	public uint angleSnapThreshold = 5;
	
	public float minColliderRadius = 0.25f;
	public float maxColliderRadius = 1f;
}
