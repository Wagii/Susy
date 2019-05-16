using UnityEngine;

[System.Serializable]
public struct Checkpoint {
	public Transform transform;
	[Range(0.5f, 100f)] public float validationRange;
	[Range(0,100)] public float percentTimeAdd;
}
