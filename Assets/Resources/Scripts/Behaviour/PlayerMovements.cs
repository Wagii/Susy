using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
[RequireComponent(typeof(SteamVR_Behaviour_Boolean))]
public class PlayerMovements : MonoBehaviour
{
    private Vector3 position, pressPosition;

    // Setup, in case
    private void Awake()
    {
        if (this.GetComponent<SteamVR_Behaviour_Pose>().origin == null)
            this.GetComponent<SteamVR_Behaviour_Pose>().origin = Manager.player.transform;
    }

    //// Update Position Value at runtime, position is Local
    //public void UpdatePosition(SteamVR_Behaviour_Pose pos, SteamVR_Input_Sources sources)
    //{
	//    this.position = transform.localPosition;
    //}
    
	protected void Update() {
		this.position = transform.localPosition;
	}

    // Save press position on input press, position is Local
    public void Press(SteamVR_Behaviour_Boolean pressType, SteamVR_Input_Sources sources, bool press)
    {
        this.pressPosition = this.position;
    }

    // Direction Apply and force manipulation
    public void Release(SteamVR_Behaviour_Boolean pressType, SteamVR_Input_Sources sources, bool press)
    {
        // If no movement is made, or if movement is not enough, stop there
        if ((this.position - this.pressPosition).magnitude < Manager.parameters.playerMovementParameters.minVectorValue) return;

        // Compute the direction of the projection, reverse or not
        var dir = Manager.parameters.playerMovementParameters.reverse ?
        	(this.pressPosition - this.position).normalized :
        	(this.position - this.pressPosition).normalized;

        // Compute the magnitude of the projection, clamped between minimum and maximum value
        var mag = Mathf.Clamp(
            (this.pressPosition - this.position).magnitude,
            Manager.parameters.playerMovementParameters.minVectorValue,
            Manager.parameters.playerMovementParameters.maxVectorValue);

        // Compute new Velocity
        // Velocity here is an = and not a += because of the next line
        Manager.player.velocity =
                        // Ternary operation to determine if projection uses force addition or velocity change
                        // If add is true, operation become 'Velocity = Velocity + newVector'
                        // If add is false operation become 'Velocity = 0 + newVector' or in other words 'Velocity = newVector'
                        (Manager.parameters.playerMovementParameters.add ? Manager.player.velocity : Vector3.zero)

                        // Now adding the newVector
	        			+ dir * mag * Manager.parameters.playerMovementParameters.playerSpeedMultiplier;
	        

        // Reset value, cuz it's better
        this.pressPosition = Vector3.zero;
    }
}
