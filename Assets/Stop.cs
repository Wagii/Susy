using UnityEngine;
using Valve.VR;

public class Stop : MonoBehaviour
{
	private float slow;
	
	protected void Start() {
		slow = Manager.parameters.slowParameters.slowSpeed;
	}
	
	public void Press (SteamVR_Behaviour_Boolean button, SteamVR_Input_Sources sources, bool press) {
		Manager.parameters.slowParameters.slowSpeed = slow * 100;
	}
	
	public void Release (SteamVR_Behaviour_Boolean button, SteamVR_Input_Sources sources, bool press) {
		Manager.parameters.slowParameters.slowSpeed = slow;
	}
}
