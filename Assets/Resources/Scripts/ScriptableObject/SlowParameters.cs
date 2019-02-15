using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Slow Parameter", menuName = "Custom/SlowParameter", order = 0)]
public class SlowParameters : ScriptableObject {
	public float slowSpeed = 1f;
	public float angularSlowSpeed = 1f;
	
}
