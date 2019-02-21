using UnityEngine;

[CreateAssetMenu(fileName = "Player Movement Parameters", menuName = "Susy/PlayerMovementParameters")]
public class PlayerMovementParameters : ScriptableObject
{
    public float minVectorValue = .1f;
    public float maxVectorValue = 5f;
	public float playerSpeedMultiplier = 1f;
	public float angleForce = 1f;
    public bool add = true;
    public bool reverse = false;
}
