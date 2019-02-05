using UnityEngine;

[CreateAssetMenu(fileName = "Collider Parameter", menuName = "Susy/ColliderParameter", order = 3)]
public class ColliderParameters : ScriptableObject {
	//public float minColliderRadius = 0.25f;
	//public float maxColliderRadius = 1f;
	public AnimationCurve colliderRadius;
	public float minSpeed = 0;
	public float maxSpeed = 10;
}
