using UnityEngine;

[CreateAssetMenu(fileName = "Object Movement Parameters", menuName = "Susy/ObjectMovementParameters")]
public class ObjectMovementParameters : ScriptableObject
{
    public float minVectorValue = .1f;
    public float maxVectorValue = 5f;
    public float objectSpeedMultiplier = 1f;
    public bool add = true;
    public bool reverse = false;
}
