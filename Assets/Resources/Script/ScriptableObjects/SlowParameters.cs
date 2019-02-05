using UnityEngine;

[CreateAssetMenu(fileName = "Slow Parameters", menuName = "Susy/SlowParameters", order = 0)]
public class SlowParameters : ScriptableObject {
	public float slowSpeedMultiplier = 1;
	public float angularSlowSpeedMultiplier = 1;
	public float slowSpeedSnap = 0.1f;
	public float angularSpeedSnap = 0.1f;
}
